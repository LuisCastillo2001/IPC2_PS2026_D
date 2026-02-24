namespace EjListasAnidadas;

public class NodoDobleCircular
{
    public Empleado Empleado { get; set; }
    public NodoDobleCircular Siguiente { get; set; }
    public NodoDobleCircular Anterior { get; set; }

    public NodoDobleCircular(Empleado empleado)
    {
        Empleado = empleado;
        Siguiente = null;
        Anterior = null;
    }
}
