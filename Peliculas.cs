namespace Models;

public class Pelicula : Contenido
{
    public string Director { get; set; }

    public Pelicula(string titulo, int duracionMinutos, string director)
        : base(titulo, duracionMinutos)
    {
        Director = director;
    }

    public override String ObtenerDescripcion()
    {
        return "Título: " + Titulo + ", Duración: " + DuracionMinutos + " min" + ", Director: " + Director;
    }
}