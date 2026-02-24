using System;

namespace EjListaEnlazadaSimple;

public class Nodo
{
    public Pelicula Pelicula;
    public Nodo Siguiente;

    public Nodo(Pelicula pelicula, Nodo siguiente = null)
    {
        Pelicula = pelicula;
        Siguiente = siguiente;
    }

}