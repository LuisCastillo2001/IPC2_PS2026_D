using System;
using EjListaEnlazadaSimple;

namespace EjListaCircular;

public class ListaCircular
{
    public NodoLC Raiz;


    public void append(NodoLC nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
            Raiz.Siguiente = Raiz; // Apunta a sí mismo para formar un círculo
        }
        else
        {
            NodoLC actual = Raiz;
            while (actual.Siguiente != Raiz) // Recorre hasta el último nodo, si el siguiente no es el Raiz, sigue avanzando
            {
                actual = actual.Siguiente;
            }
            // encuentra el actual y su siguiente es el Raiz, entonces actual es el último nodo, el siguiente es la direccion de memoria de la raiz, no comparo 
            // directamente el objeto si no la dirrecion de memoria
            actual.Siguiente = nuevoNodo; // El último nodo apunta al nuevo nodo
            nuevoNodo.Siguiente = Raiz; // El nuevo nodo apunta al Raiz para cerrar el círculo
        }
    }

    public void print()
    {
        if (Raiz == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        NodoLC actual = Raiz;
        do
        {
           Console.WriteLine($"Titulo: {actual.Libro.Titulo}, Autor: {actual.Libro.Autor}, Año: {actual.Libro.Anio}"); // Imprime el libro del nodo actual
            actual = actual.Siguiente;
        } while (actual != Raiz); // Recorre hasta volver al Raiz
        // cuando la direccion de memoria del nodo actual es igual a la direccion de memoria del Raiz, se detiene el ciclo
    }

    public void pop()
    {
        if (Raiz == null)
        {
            Console.WriteLine("La lista está vacía. No se puede eliminar ningún nodo.");
            return;
        }

        if (Raiz.Siguiente == Raiz) // Si solo hay un nodo en la lista
        {
            Raiz = null; // Elimina el único nodo
            return;
        }

        NodoLC actual = Raiz;
        while (actual.Siguiente.Siguiente != Raiz) // Recorre hasta el último nodo
        {
            actual = actual.Siguiente;
        }
        // encuentra el actual y su siguiente es el Raiz, entonces actual es el último nodo, el siguiente es la direccion de memoria de la raiz, no comparo 
        // directamente el objeto si no la dirrecion de memoria
        actual.Siguiente = Raiz;  // elimino el ultimo nodo apuntando el siguiente del penultimo nodo a la raiz, el nodo que era el ultimo queda sin referencias y el recolector de basura se encargará de liberar la memoria
    }
}
