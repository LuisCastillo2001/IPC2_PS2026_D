namespace EjListasAnidadas;

public class Departamento
{
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public ListaDobleCircular Empleados { get; set; }

    public Departamento(string nombre, string ubicacion)
    {
        Nombre = nombre;
        Ubicacion = ubicacion;
        Empleados = new ListaDobleCircular();
    }
}
