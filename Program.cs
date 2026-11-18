using Models;

Console.WriteLine("========== STREAMING ==========");

Console.WriteLine("");

// ################################################## //
// BLOQUE 1 - COLECCIÓN Y MÉTODOS //
// ################################################## //

#region Ejercicio 4 - Colección de contenidos

Console.WriteLine("========== Colección de contenidos ==========");

List<Contenido> contenidos =
[
    new Pelicula("El calamar", 148, "Pablo Ubieto"),
    new Pelicula("El asesino", 175, "Roberto"),
    new Series("SWAT", 47, 5),
    new Series("Stranger Things", 50, 4),
    new Documentales("Planeta Tierra", 50, "Naturaleza")
];

foreach (Contenido contenido in contenidos)
{
    Console.WriteLine(contenido.ObtenerDescripcion());
}

Console.WriteLine("");

#endregion

#region Ejercicio 5 - Búsqueda de contenidos

Console.WriteLine("========== Búsqueda de contenidos ==========");
Console.Write("Búsqueda correcta -> ");
BuscarPorTitulo(contenidos, "inCEPtion");

Console.Write("Búsqueda sin resultados -> ");
BuscarPorTitulo(contenidos, "Titanic");

Console.WriteLine("");

#endregion

#region Ejercicio 6 - Filtrado de contenidos

Console.WriteLine("========== Filtrado por duración (60 min) ==========");
FiltrarPorDuracion(contenidos, 60);

Console.WriteLine("========== Filtrado por duración (10 min) ==========");
FiltrarPorDuracion(contenidos, 10);

Console.WriteLine("========== Filtrado por tipo (películas) ==========");
MostrarPeliculas(contenidos);

Console.WriteLine("");

#endregion

#region Ejercicio 7 - Estadísticas de contenidos

MostrarEstadisticas(contenidos);

Console.WriteLine("");

#endregion

// ################################################## //
// BLOQUE 2 - MENÚ Y VALIDACIÓN //
// ################################################## //

#region Ejercicio 8 - Menú interactivo

MostrarMenu(contenidos);

#endregion

// ################################################## //
// MÉTODOS //
// ################################################## //

#region Métodos

static void BuscarPorTitulo(List<Contenido> contenidos, string titulo)
{
    foreach (Contenido contenido in contenidos)
    {
        if (contenido.Titulo.Equals(titulo.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine(contenido.ObtenerDescripcion());
            return;
        }
    }

    Console.WriteLine($"No se ha encontrado ningún contenido con el título \"{titulo}\".");
}

static void FiltrarPorDuracion(List<Contenido> contenidos, int duracionMaxima)
{
    if (duracionMaxima < 0)
    {
        Console.WriteLine("La duración máxima no puede ser negativa.");
        return;
    }

    bool Coincidencias = false;

    foreach (Contenido contenido in contenidos)
    {
        if (contenido.DuracionMinutos <= duracionMaxima)
        {
            Console.WriteLine(contenido.ObtenerDescripcion());
            Coincidencias = true;
        }
    }

    if (!Coincidencias)
    {
        Console.WriteLine($"No hay contenidos de {duracionMaxima} minutos o menos.");
    }
}

static void MostrarPeliculas(List<Contenido> contenidos)
{
    foreach (Contenido contenido in contenidos)
    {
        if (contenido is Pelicula)
        {
            Console.WriteLine(contenido.ObtenerDescripcion());
        }
    }
}

static void MostrarEstadisticas(List<Contenido> contenidos)
{
    int total = 0;
    int peliculas = 0;
    int series = 0;
    int documentales = 0;

    foreach (Contenido contenido in contenidos)
    {
        total++;

        if (contenido is Pelicula)
        {
            peliculas++;
        }
        else if (contenido is Series)
        {
            series++;
        }
        else if (contenido is Documentales)
        {
            documentales++;
        }
    }

    Console.WriteLine("=== ESTADÍSTICAS ===");
    Console.WriteLine($"Total contenidos: {total}");
    Console.WriteLine($"Películas: {peliculas}");
    Console.WriteLine($"Series: {series}");
    Console.WriteLine($"Documentales: {documentales}");
}

static void MostrarMenu(List<Contenido> contenidos)
{
    int opcion = -1;

    while (opcion != 0)
    {
        Console.WriteLine("\n=== STREAMING ===");
        Console.WriteLine("1. Ver todas los contenidos");
        Console.WriteLine("2. Buscar contenido");
        Console.WriteLine("3. Filtrar por duración");
        Console.WriteLine("4. Mostrar películas");
        Console.WriteLine("5. Ver estadísticas");
        Console.WriteLine("6. Salir");
        Console.Write("Selecciona una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("\nDebes introducir un número.");
            opcion = -1;
            continue;
        }

        Console.WriteLine("");

        switch (opcion)
        {
            case 1:
                foreach (Contenido contenido in contenidos)
                {
                    Console.WriteLine(contenido.ObtenerDescripcion());
                }
                break;

            case 2:
                Console.Write("Título a buscar: ");
                BuscarPorTitulo(contenidos, Console.ReadLine() ?? "");
                break;

            case 3:
                Console.Write("Duración máxima (minutos): ");
                if (!int.TryParse(Console.ReadLine(), out int maxima))
                {
                    Console.WriteLine("Debes introducir un número.");
                }
                else if (maxima < 0)
                {
                    Console.WriteLine("La duración máxima no puede ser negativa.");
                }
                else
                {
                    FiltrarPorDuracion(contenidos, maxima);
                }
                break;

            case 4:
                MostrarPeliculas(contenidos);
                break;

            case 5:
                MostrarEstadisticas(contenidos);
                break;

            case 6:
                Console.WriteLine("Adiós");
                break;

            default:
                Console.WriteLine("Error: selecciona una opción válida.");
                break;
        }
    }
}

#endregion
