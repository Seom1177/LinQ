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
    public IEnumerable<Book> LibrosJavaPorNombreAcendente(){
        return librosCollection.Where(p => p.Categories.Contains("Java"))
                                .OrderBy(p => p.Title);
    }
    public IEnumerable<Book> LibrosDeMAsDe450PagOrdenadosDecendente(){
        return librosCollection.Where(p => p.PageCount > 450)
                                .OrderByDescending(p => p.PageCount);
    }
    public IEnumerable<Book> Libros3PrimerosLibrosOrdenadosPorFecha(){
        return librosCollection.Where(p => p.Categories.Contains("Java"))
                                //.OrderByDescending(p => p.PublishedDate)
                                .OrderBy(p => p.PublishedDate)
                                //.Take(3);   // toma los primeros
                                .TakeLast(3); //toma ultimos 3
                                //.TakeWhile toma segun condicion
    }
    public IEnumerable<Book> TercerYCuartoLibroMayor400Pag(){
        return librosCollection
            .Where(p => p.PageCount > 400)
            .Take(4)
            .Skip(2);
    }
    public IEnumerable<Book> TresPrimerosLibrosDeLaColleccion(){
        return librosCollection
            .Take(3)
            .Select( p => new Book { Title = p.Title, PageCount = p.PageCount});
    }
    public int CantidadDeLibrosEntre200y500(){
        return librosCollection.Count(p=> p.PageCount >= 200 &&
                                            p.PageCount <= 500);
    }
    public long CantidadDeLibrosEntre200y500Long(){
        return librosCollection.Where(p=> p.PageCount >= 200 &&
                                            p.PageCount <= 500).LongCount();
    }
    public DateTime FechaDePublicacionMenor(){
        return librosCollection.Min(p=>p.PublishedDate);
    }
    public int NumeroDePagMayor(){
        return librosCollection.Max(p=>p.PageCount);
    }
    public Book? LibroMenorNumPag(){
        return librosCollection.Where(p=>p.PageCount > 0).MinBy(p=>p.PageCount);
    }
    public Book? LibroFechaPublicacionReciente(){
        return librosCollection.MaxBy(p=>p.PublishedDate);
    }
    public int SumaDeTodasLasPag200a500(){
        return librosCollection
            .Where(p=> p.PageCount >= 0 && p.PageCount <= 500)
            .Sum(p=>p.PageCount);
    }
    public string TitulosLibrosDespuesDel2015Concat(){
        return librosCollection
            .Where(p=> p.PublishedDate.Year > 2015)
            .Aggregate("", (TitulosLibros, next) =>{
                if (TitulosLibros != string.Empty)
                    TitulosLibros += " - " + next.Title;
                else
                    TitulosLibros += next.Title;
                return TitulosLibros;
            });
    }
    public double PromedioCaracteresTitulo(){
        return librosCollection
            .Average(p=>p.Title.Length);
    }
    public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorAgno(){
        return librosCollection
            .Where(p=> p.PublishedDate.Year > 2000)
            .GroupBy(p=> p.PublishedDate.Year);
    }
    public ILookup<char, Book> DiccionarioDeLibrosPorLetra(){
        return librosCollection.ToLookup(p=> p.Title[0], p=> p);
    }
    public IEnumerable<Book> LibrosDespues2005ConMasDe500Pags(){
        var LibrosDespues2005 = librosCollection
                                    .Where(p=>p.PublishedDate.Year > 2005);
        var librosConMas500Pag = librosCollection
                                    .Where(p=>p.PageCount > 500);
        return librosConMas500Pag
                    .Join(LibrosDespues2005, p=>p.Title,x=>x.Title, (p, x)=> p);
    }
}