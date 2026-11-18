namespace Models;

public class Documentales : Contenido
{
    public string Tematica { get; set; }

    public Documentales(string titulo, int duracionMinutos, string tematica)
        : base(titulo, duracionMinutos)
    {
        Tematica = tematica;
    }

    public override String ObtenerDescripcion()
    {
        return "Título: " + Titulo + ", Duración: " + DuracionMinutos + " min" + ", Tematica: " + Tematica;
    }
}