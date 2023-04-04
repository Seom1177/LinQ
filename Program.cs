LinqQueries queries = new LinqQueries();

// Toda la colleccion
//ImprimirValores(queries.TodaLaColeccion());

// where Libros despues del 2000
//ImprimirValores(queries.LibrosDespues2000());

// where Estos son los libros con mas de 250 pag y contienen en el titulo la palabra "in action"
//ImprimirValores(queries.LibrosConMasDe250PagConPalabraInAction());

// All Todos los libros tienen status
//Console.WriteLine($"Todos los libros tienen status? = {queries.TodosLosLibrosTienenStatus()}");

// Any Algun libro fue publicado en 2005
//Console.WriteLine($"Algun libro fue publicado en 2005? = {queries.AlgunLibroPublicadoEn2005()}");

// Contains Libros de Python
//ImprimirValores(queries.LibrosPython());

// OrderBy Libros de java ordenados por nombre
//ImprimirValores(queries.LibrosJavaPorNombreAcendente());

// OrderByDescending Libros con mas de 450 pag ordenados por cantidad de paginas
//ImprimirValores(queries.LibrosDeMAsDe450PagOrdenadosDecendente());

// Take los 3 libros de java mas recientemente publicados 
//ImprimirValores(queries.Libros3PrimerosLibrosOrdenadosPorFecha());

// Skip Tercer y 4 libro con mas de 400 paginas
//ImprimirValores(queries.TercerYCuartoLibroMayor400Pag());

// Select Tres primeros libros filtrados con select
//ImprimirValores(queries.TresPrimerosLibrosDeLaColleccion());

// Count cantidad de libros
//Console.WriteLine($"Cantidad de libros entre 200 y 500: {queries.CantidadDeLibrosEntre200y500()}");

// LongCount cantidad de libros
//Console.WriteLine($"Cantidad de libros entre 200 y 500: {queries.CantidadDeLibrosEntre200y500Long()}");

// Min Fecha menor de publicacion
//Console.WriteLine($"Fecha menor de publicacion: {queries.FechaDePublicacionMenor()}");

//  Max NUmero de paginas maximo
//Console.WriteLine($"El mayor numero de paginas en la collecion: {queries.NumeroDePagMayor()}");

// MinBy libro con el menor numero de paginas
//var libroMenorPag = queries.LibroMenorNumPag();
//Console.WriteLine($"{libroMenorPag!.Title} - {libroMenorPag.PageCount}");

// MaxBy libro con la fecha publicacion mas reciente
// var libroMaxFecha = queries.LibroFechaPublicacionReciente();
// Console.WriteLine($"{libroMaxFecha!.Title} - {libroMaxFecha.PublishedDate.ToShortDateString()}");

// Sum suma paginas entre 0 a 500 por libro
// Console.WriteLine($"Suma total de paginas {queries.SumaDeTodasLasPag200a500()}");

// Aggregate Libros publicados despues del 2015
// Console.WriteLine(queries.TitulosLibrosDespuesDel2015Concat());

// Average El promedio de caracteres de los titulos de los libros
// Console.WriteLine($"Promedio char titulos libros {queries.PromedioCaracteresTitulo()}");

// GroupBy Llibros agrupados por año despues del 2000
// ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorAgno());

// LookUp Diccionario De libros agrupados por primera letra
// ImprimirDiccionario(queries.DiccionarioDeLibrosPorLetra(), 'T');

// Join Libros filtrados con la clausula de Join
ImprimirValores(queries.LibrosDespues2005ConMasDe500Pags());

void ImprimirValores (IEnumerable<Book> listadeLibros){
    Console.WriteLine("{0, -60} {1, 15} {2, 17}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadeLibros){
        Console.WriteLine("{0, -60} {1, 15} {2, 17}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
void ImprimirGrupo (IEnumerable<IGrouping<int, Book>> listadeLibros){
    foreach(var grupo in listadeLibros){
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0, -60} {1, 15} {2, 17}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo){
            Console.WriteLine("{0, -60} {1, 15} {2, 17}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}
void ImprimirDiccionario (ILookup<char, Book> listadeLibros, char letra){
    Console.WriteLine("{0, -60} {1, 15} {2, 17}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadeLibros[letra]){
        Console.WriteLine("{0, -60} {1, 15} {2, 17}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}