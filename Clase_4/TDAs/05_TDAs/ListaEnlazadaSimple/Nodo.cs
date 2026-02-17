using System;

namespace EjListaEnlazadaSimple;

public class Nodo
{
    public Pelicula Pelicula;
    public Nodo Siguiente;

    // Si pongo = agrego el valor por defecto, si no mando el valor, se asigna el valor por defecto
    // La pelicula es obligatoria, el siguiente es opcional, por eso el valor por defecto es null
    public Nodo(Pelicula pelicula, Nodo siguiente = null)
    {
        Pelicula = pelicula;
        Siguiente = siguiente;
    }

}
