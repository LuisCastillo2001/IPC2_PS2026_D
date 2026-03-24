using System.Text;
using Clase_8.Models;

namespace Clase_8.Estructuras;

public class ListaDrones
{
    public NodoDron Raiz { get; set; }

    public ListaDrones()
    {
        Raiz = null;
    }

    public void Agregar(Dron dron)
    {
        NodoDron nuevoNodo = new NodoDron(dron);
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
        }
        else
        {
            NodoDron nodoActual = Raiz;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            nodoActual.Siguiente = nuevoNodo;
        }
    }

    public Dron ObtenerDron(string nombre)
    {
        NodoDron nodoActual = Raiz;
        while (nodoActual != null)
        {
            if (nodoActual.Dron.Nombre == nombre)
            {
                return nodoActual.Dron;
            }
            nodoActual = nodoActual.Siguiente;
        }
        return null;
    }

    public string Listar()
    {
        if (Raiz == null)
        {
            return "La lista de drones está vacía.";
        }

        StringBuilder texto = new StringBuilder();
        NodoDron nodoActual = Raiz;
        int indice = 1;

        while (nodoActual != null)
        {
            texto.AppendLine($"#{indice} | {nodoActual.Dron.ToString()}");
            nodoActual = nodoActual.Siguiente;
            indice++;
        }

        return texto.ToString();
    }

    public void Limpiar()
    {
        Raiz = null;
    }

    public int Contar()
    {
        int cantidad = 0;
        NodoDron nodoActual = Raiz;
        while (nodoActual != null)
        {
            cantidad++;
            nodoActual = nodoActual.Siguiente;
        }
        return cantidad;
    }
}
