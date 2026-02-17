using System;

namespace EjListaEnlazadaSimple;

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
