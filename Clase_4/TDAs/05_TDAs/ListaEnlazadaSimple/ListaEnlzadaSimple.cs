using System;

namespace EjListaEnlazadaSimple;

public class ListaEnlzadaSimple
{
    public Nodo Raiz;

    // No es necesario un constructor, ya que la raiz se inicializa con null por defecto
    public void append(Nodo nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
        }
        else
        {
            Nodo nodoActual = Raiz;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            nodoActual.Siguiente = nuevoNodo;
        }
    }

    public void print()
    {
        Nodo nodoActual = Raiz;
        while (nodoActual != null)
        {
            Console.WriteLine($"Titulo: {nodoActual.Pelicula.Titulo}, Director: {nodoActual.Pelicula.Director}, Año: {nodoActual.Pelicula.Anio}");
            nodoActual = nodoActual.Siguiente;
        }
    }

    public void reset()
    {
        // para resetear la lista, basta con asignar null a la raiz, el recolector de basura se encargará de liberar la memoria
        Raiz = null;
    }

    public void pop()
    {
        // are que borre el ultimo nodo
        if (Raiz == null)
        {
            Console.WriteLine("La lista está vacía");
            return;
        }

        if (Raiz.Siguiente == null)
        {
            Raiz = null;
            return;
        }

        Nodo nodoActual = Raiz;
        while (nodoActual.Siguiente.Siguiente != null)
        {
            nodoActual = nodoActual.Siguiente;
        }
        nodoActual.Siguiente = null;
    }

}
