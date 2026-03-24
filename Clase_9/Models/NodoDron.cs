namespace Clase_8.Models;

public class NodoDron
{
    public Dron Dron { get; set; }
    public NodoDron Siguiente { get; set; }

    public NodoDron(Dron dron, NodoDron siguiente = null)
    {
        Dron = dron;
        Siguiente = siguiente;
    }
}
