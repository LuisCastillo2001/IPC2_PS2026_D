namespace Clase_8.Models;

public class Dron
{
    public string Nombre { get; set; }
    public int AlturaActual { get; set; }
    public int AlturaMaxima { get; set; }
    public bool LuzActiva { get; set; }

    public Dron(string nombre, int alturaMaxima = 100)
    {
        Nombre = nombre;
        AlturaActual = 0;
        AlturaMaxima = alturaMaxima;
        LuzActiva = false;
    }

    public override string ToString()
    {
        return $"Dron: {Nombre} | Altura: {AlturaActual}m | Luz: {(LuzActiva ? "ON" : "OFF")}";
    }
}
