using System.Collections;
using System.Text.Json;
public class LinqQueries{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries(){
        using(StreamReader reader = new StreamReader("books.json")){
            string json = reader.ReadToEnd();
            this.librosCollection = JsonSerializer
                    .Deserialize<List<Book>>(json, new JsonSerializerOptions(){
                PropertyNameCaseInsensitive = true
            })!;
        }
    }
    public IEnumerable<Book> TodaLaColeccion(){
        return librosCollection;
    }
    public IEnumerable<Book> LibrosDespues2000(){
        // Extension method
        //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

        // query expression
        return from  l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }
    public IEnumerable<Book> LibrosConMasDe250PagConPalabraInAction(){
        // extension methods
        //return librosCollection.Where(p => p.PageCount > 250 &&
        //                                p.Title.Contains("in Action"));

        // query expression
        return from l in librosCollection where l.PageCount > 250 &&
                                                l.Title.Contains("in Action")
                                                select l;
    }
    public bool TodosLosLibrosTienenStatus(){
        return librosCollection.All(p => p.Status != string.Empty);
    }
    public bool AlgunLibroPublicadoEn2005(){
        return librosCollection.Any( p => p.PublishedDate.Year == 2005);
    }
    public IEnumerable<Book> LibrosPython(){
        return librosCollection.Where(p => p.Categories.Contains("Python"));
    }
}