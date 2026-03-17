namespace Clase_8.Models;

public class Nodo
{
    public Pelicula Pelicula;
    public Nodo Siguiente;

    public Nodo(Pelicula pelicula, Nodo siguiente = null)
    {
        Pelicula = pelicula;
        Siguiente = siguiente;
    }
}
