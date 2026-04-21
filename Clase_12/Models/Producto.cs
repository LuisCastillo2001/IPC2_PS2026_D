namespace Clase_12.Models;

public sealed class Producto
{
    public int Id { get; init; }
    public required string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}
