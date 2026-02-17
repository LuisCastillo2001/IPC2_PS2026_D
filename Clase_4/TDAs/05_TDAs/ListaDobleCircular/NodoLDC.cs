using System;

namespace EjListaDobleCircular;

public class NodoLDC
{
    public Libro Libro;

    // para indicar que pueden ser nulos, tanto Siguiente como Anterior, se utiliza el operador "?" después del tipo de dato.
    // esto le dice al compilador que estas variables pueden contener un valor nulo, lo que es útil para representar el final de la lista o el inicio de la lista en una estructura de datos como una lista doble circular.
    public NodoLDC? Siguiente;

    public NodoLDC? Anterior;
    // el signo ? se pude despues del tipo de variable y no despues del nombre de la variable
    // esto es asi porque el signo ? se utiliza para indicar que el tipo de dato puede ser nulo, y debe colocarse inmediatamente después del tipo de dato para que el compilador lo reconozca correctamente.
    // se refiere a que puede ser NodoLDC o null

    public NodoLDC(Libro libro)
    {
        Libro = libro;
        Siguiente = null;
        Anterior = null;
    }
}
