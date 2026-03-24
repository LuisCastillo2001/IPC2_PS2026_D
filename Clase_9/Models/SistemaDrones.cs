namespace Clase_8.Models;

public class NodoDronAlturas
{
    public string NombreDron { get; set; }
    public ListaAlturaLetra Alturas { get; set; }
    public NodoDronAlturas Siguiente { get; set; }

    public NodoDronAlturas(string nombreDron, NodoDronAlturas siguiente = null)
    {
        NombreDron = nombreDron;
        Alturas = new ListaAlturaLetra();
        Siguiente = siguiente;
    }
}

public class ListaDronesAlturas
{
    public NodoDronAlturas Raiz { get; set; }

    public void AgregarDron(string nombreDron)
    {
        var nuevoNodo = new NodoDronAlturas(nombreDron);
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

    public ListaAlturaLetra ObtenerAlturasDron(string nombreDron)
    {
        var nodoActual = Raiz;
        while (nodoActual != null)
        {
            if (nodoActual.NombreDron == nombreDron)
            {
                return nodoActual.Alturas;
            }
            nodoActual = nodoActual.Siguiente;
        }
        return null;
    }

    public void Limpiar()
    {
        Raiz = null;
    }
}

public class SistemaDrones
{
    public string Nombre { get; set; }
    public int AlturaMaxima { get; set; }
    public int CantidadDrones { get; set; }
    public ListaDronesAlturas DronesAlturas { get; set; }

    public SistemaDrones(string nombre, int alturaMaxima)
    {
        Nombre = nombre;
        AlturaMaxima = alturaMaxima;
        CantidadDrones = 0;
        DronesAlturas = new ListaDronesAlturas();
    }

    public void AgregarAltura(int altura, string dron, string letra)
    {
        var alturasDron = DronesAlturas.ObtenerAlturasDron(dron);
        if (alturasDron == null)
        {
            DronesAlturas.AgregarDron(dron);
            alturasDron = DronesAlturas.ObtenerAlturasDron(dron);
        }
        alturasDron.Agregar(altura, letra);
    }

    public string ObtenerLetra(string dron, int altura)
    {
        var alturasDron = DronesAlturas.ObtenerAlturasDron(dron);
        if (alturasDron != null)
        {
            return alturasDron.ObtenerLetra(altura);
        }
        return "?";
    }
}
