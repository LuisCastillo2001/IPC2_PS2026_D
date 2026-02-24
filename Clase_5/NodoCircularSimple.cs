namespace EjListasAnidadas;

public class NodoCircularSimple
{
    public Departamento Departamento { get; set; }
    public NodoCircularSimple Siguiente { get; set; }

    public NodoCircularSimple(Departamento departamento)
    {
        Departamento = departamento;
        Siguiente = null;
    }
}
