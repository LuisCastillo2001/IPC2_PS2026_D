using System;

namespace EjListaEnlazadaDoble;

public class ListaEnlazadaDoble
{
    public NodoLED Raiz;

    public void append(NodoLED nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
        }
        else
        {
            NodoLED nodoActual = Raiz;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            nodoActual.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = nodoActual;
        }
    }

    public void printAcendente()
    {
        NodoLED nodoActual = Raiz;
        while (nodoActual != null)
        {
            Console.WriteLine($"Titulo: {nodoActual.Libro.Titulo}, Autor: {nodoActual.Libro.Autor}, Año: {nodoActual.Libro.Anio}");
            nodoActual = nodoActual.Siguiente;
        }
    }

    public void printDescendente()
    {
        NodoLED nodoActual = Raiz;
        if (nodoActual == null)
        {
            Console.WriteLine("La lista está vacía");
            return;
        }
        while (nodoActual.Siguiente != null)
        {
            nodoActual = nodoActual.Siguiente;
        }
        while (nodoActual != null)
        {
            Console.WriteLine($"Titulo: {nodoActual.Libro.Titulo}, Autor: {nodoActual.Libro.Autor}, Año: {nodoActual.Libro.Anio}");
            nodoActual = nodoActual.Anterior;
        }
    }

    public void reset()
    {
        
        Raiz = null;
    }

    public void pop()
    {
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

        NodoLED nodoActual = Raiz;
        while (nodoActual.Siguiente != null)
        {
            nodoActual = nodoActual.Siguiente;
        }
        nodoActual.Anterior.Siguiente = null;
    }


}