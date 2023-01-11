LinqQueries queries = new LinqQueries();

// Toda la colleccion
//ImprimirValores(queries.TodaLaColeccion());

//Libros despues del 2000
//ImprimirValores(queries.LibrosDespues2000());

// Estos son los libros con mas de 250 pag y contienen en el titulo la palabra "in action"
//ImprimirValores(queries.LibrosConMasDe250PagConPalabraInAction());

// Todos los libros tienen status
//Console.WriteLine($"Todos los libros tienen status? = {queries.TodosLosLibrosTienenStatus()}");

// Algun libro fue publicado en 2005
//Console.WriteLine($"Algun libro fue publicado en 2005? = {queries.AlgunLibroPublicadoEn2005()}");

// Libros de Python
ImprimirValores(queries.LibrosPython());

void ImprimirValores (IEnumerable<Book> listadeLibros){
    Console.WriteLine("{0, -60} {1, 15} {2, 17}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadeLibros){
        Console.WriteLine("{0, -60} {1, 15} {2, 17}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}