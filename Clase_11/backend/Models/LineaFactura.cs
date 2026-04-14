namespace Clase_11.Models;

public class LineaFactura
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}
