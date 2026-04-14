namespace Clase_11.Models;

public class Factura
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public decimal Total { get; set; }
    public List<LineaFactura> Lineas { get; set; } = new();
}
