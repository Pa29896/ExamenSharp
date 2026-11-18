namespace Models;

public abstract class Contenido
{
    public string Titulo { get; set; }
    public int DuracionMinutos { get; set; }

    protected Contenido(string titulo, int duracionMinutos)
    {
        Titulo = titulo;
        DuracionMinutos = duracionMinutos;
    }

    public abstract String ObtenerDescripcion();
}