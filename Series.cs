namespace Models;

public class Series : Contenido
{
    public int Temporadas { get; set; }

    public Series(string titulo, int duracionMinutos, int temporadas) : base(titulo, duracionMinutos)
    {
        Temporadas = temporadas;
    }

    public override String ObtenerDescripcion()
    {
        return "Título: " + Titulo + ", Duración: " + DuracionMinutos + " min" + ", Numero de temporadas: " + Temporadas;
    }
}