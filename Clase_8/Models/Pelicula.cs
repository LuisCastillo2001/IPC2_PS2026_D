namespace Clase_8.Models;

public class Pelicula
{
    public string Titulo;
    public string Director;
    public int Anio;

    public Pelicula(string titulo, string director, int anio)
    {
        Titulo = titulo;
        Director = director;
        Anio = anio;
    }
}
