namespace Clase_8.Models;

public class ParAlturaLetra
{
    public int Altura { get; set; }
    public string Letra { get; set; }

    public ParAlturaLetra(int altura, string letra)
    {
        Altura = altura;
        Letra = letra;
    }
}

public class NodoAlturaLetra
{
    public ParAlturaLetra Dato { get; set; }
    public NodoAlturaLetra Siguiente { get; set; }

    public NodoAlturaLetra(ParAlturaLetra dato, NodoAlturaLetra siguiente = null)
    {
        Dato = dato;
        Siguiente = siguiente;
    }
}

public class ListaAlturaLetra
{
    public NodoAlturaLetra Raiz { get; set; }

    public void Agregar(int altura, string letra)
    {
        var nuevoNodo = new NodoAlturaLetra(new ParAlturaLetra(altura, letra));
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

    public string ObtenerLetra(int altura)
    {
        var nodoActual = Raiz;
        while (nodoActual != null)
        {
            if (nodoActual.Dato.Altura == altura)
            {
                return nodoActual.Dato.Letra;
            }
            nodoActual = nodoActual.Siguiente;
        }
        return "?";
    }

    public void Limpiar()
    {
        Raiz = null;
    }
}
