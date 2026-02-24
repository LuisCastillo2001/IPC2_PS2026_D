namespace EjListasAnidadas;

public class Empleado
{
    public string Nombre { get; set; }
    public string Puesto { get; set; }
    public int Salario { get; set; }

    public Empleado(string nombre, string puesto, int salario)
    {
        Nombre = nombre;
        Puesto = puesto;
        Salario = salario;
    }
}
