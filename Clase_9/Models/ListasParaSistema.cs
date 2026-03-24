namespace Clase_8.Models;

public class NodoSistemaDrones
{
    public SistemaDrones Sistema { get; set; }
    public NodoSistemaDrones Siguiente { get; set; }

    public NodoSistemaDrones(SistemaDrones sistema, NodoSistemaDrones siguiente = null)
    {
        Sistema = sistema;
        Siguiente = siguiente;
    }
}

public class ListaSistemasDrones
{
    public NodoSistemaDrones Raiz { get; set; }

    public void Agregar(SistemaDrones sistema)
    {
        var nuevoNodo = new NodoSistemaDrones(sistema);
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
        }
        else
        {
            var nodoActual = Raiz;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            nodoActual.Siguiente = nuevoNodo;
        }
    }

    public SistemaDrones Obtener(string nombre)
    {
        var nodoActual = Raiz;
        while (nodoActual != null)
        {
            if (nodoActual.Sistema.Nombre == nombre)
            {
                return nodoActual.Sistema;
            }
            nodoActual = nodoActual.Siguiente;
        }
        return null;
    }

    public int Contar()
    {
        int contador = 0;
        var nodoActual = Raiz;
        while (nodoActual != null)
        {
            contador++;
            nodoActual = nodoActual.Siguiente;
        }
        return contador;
    }

    public void Limpiar()
    {
        Raiz = null;
    }
}

public class NodoDronNombre
{
    public string NombreDron { get; set; }
    public NodoDronNombre Siguiente { get; set; }

    public NodoDronNombre(string nombre, NodoDronNombre siguiente = null)
    {
        NombreDron = nombre;
        Siguiente = siguiente;
    }
}

public class ListaDronesNombres
{
    public NodoDronNombre Raiz { get; set; }

    public void Agregar(string nombre)
    {
        var nuevoNodo = new NodoDronNombre(nombre);
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
        }
        else
        {
            var nodoActual = Raiz;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            nodoActual.Siguiente = nuevoNodo;
        }
    }

    public bool Existe(string nombre)
    {
        var nodoActual = Raiz;
        while (nodoActual != null)
        {
            if (nodoActual.NombreDron == nombre)
            {
                return true;
            }
            nodoActual = nodoActual.Siguiente;
        }
        return false;
    }

    public void Limpiar()
    {
        Raiz = null;
    }
}
