using System;
using EjListaEnlazadaSimple;

namespace EjListaDobleCircular;

public class ListaDobleCircular
{
    public NodoLDC? Raiz;
    public NodoLDC? Ultimo;

    public void append(NodoLDC nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
            Ultimo = nuevoNodo;
            nuevoNodo.Siguiente = Raiz;
            nuevoNodo.Anterior = Ultimo;
        }
        else
        {
            // el ! se utiliza para indicar que estamos seguros de que Ultimo no es nulo en este punto del código. Esto es necesario porque el compilador de C# no puede determinar si Ultimo podría ser nulo o no, y sin el !, el compilador generaría un error de compilación al intentar acceder a la propiedad Siguiente de Ultimo.
            
            Ultimo!.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = Ultimo;
            Ultimo = nuevoNodo;
            Ultimo.Siguiente = Raiz;
            Raiz.Anterior = Ultimo;
        }
    }

    public void print()
    {
        if (Raiz == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        NodoLDC? actual = Raiz;
        do
        {
            Console.WriteLine($"Título: {actual?.Libro.Titulo}, Autor: {actual?.Libro.Autor}, Año: {actual?.Libro.Anio}");
            actual = actual.Siguiente;
        } while (actual != Raiz);
    }
}
