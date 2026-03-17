using Clase_8.Estructuras;
using Clase_8.Models;

namespace Clase_8.Servicios;

public class ListaEnlazadaService
{
    public ListaEnlazadaSimple Lista;

    public ListaEnlazadaService()
    {
        Lista = new ListaEnlazadaSimple();
    }

    public void Agregar(string titulo, string director, int anio)
    {
        Pelicula pelicula = new Pelicula(titulo, director, anio);
        Nodo nuevoNodo = new Nodo(pelicula);
        Lista.append(nuevoNodo);
    }

    public bool EliminarUltimo()
    {
        return Lista.pop();
    }

    public void Limpiar()
    {
        Lista.reset();
    }

    public string Imprimir()
    {
        return Lista.print();
    }
}
