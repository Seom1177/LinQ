LinqQueries queries = new LinqQueries();

ImprimirValores(queries.TodaLaColeccion());

void ImprimirValores (IEnumerable<Book> listadeLibros){
    Console.WriteLine("{0, -60} {1, 15} {2, 17}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadeLibros){
        Console.WriteLine("{0, -60} {1, 15} {2, 17}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}