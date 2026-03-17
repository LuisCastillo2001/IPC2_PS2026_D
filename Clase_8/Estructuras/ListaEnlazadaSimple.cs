using System.Text;
using Clase_8.Models;

namespace Clase_8.Estructuras;

public class ListaEnlazadaSimple
{
    public Nodo Raiz;

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

    public string print()
    {
        if (Raiz == null)
        {
            return "La lista esta vacia.";
        }

        StringBuilder texto = new StringBuilder();
        Nodo nodoActual = Raiz;
        int indice = 1;

        while (nodoActual != null)
        {
            texto.AppendLine(
                "#" + indice +
                " | Titulo: " + nodoActual.Pelicula.Titulo +
                " | Director: " + nodoActual.Pelicula.Director +
                " | Anio: " + nodoActual.Pelicula.Anio
            );

            nodoActual = nodoActual.Siguiente;
            indice = indice + 1;
        }

        return texto.ToString();
    }

    public void reset()
    {
        Raiz = null;
    }

    public bool pop()
    {
        if (Raiz == null)
        {
            return false;
        }

        if (Raiz.Siguiente == null)
        {
            Raiz = null;
            return true;
        }

        Nodo nodoActual = Raiz;
        while (nodoActual.Siguiente.Siguiente != null)
        {
            nodoActual = nodoActual.Siguiente;
        }

        nodoActual.Siguiente = null;
        return true;
    }
}
