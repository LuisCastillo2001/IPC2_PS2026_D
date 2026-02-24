using System;

namespace EjListaEnlazadaDoble;

public class NodoLED
{
    public Libro Libro;
    public NodoLED Siguiente;
    public NodoLED Anterior;
    public NodoLED(Libro libro)
    {
        Libro = libro;
        Siguiente = null;
        Anterior = null;
    }

}
