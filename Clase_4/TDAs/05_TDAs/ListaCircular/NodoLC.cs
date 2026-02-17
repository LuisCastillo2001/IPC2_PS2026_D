using System;

namespace EjListaCircular;

public class NodoLC
{
    public Libro Libro;
    public NodoLC Siguiente;

    public NodoLC(Libro libro)
    {
        Libro = libro;
        Siguiente = null;
    }
}
