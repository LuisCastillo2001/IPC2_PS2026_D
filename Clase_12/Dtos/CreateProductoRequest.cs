using System.ComponentModel.DataAnnotations;

namespace Clase_12.Dtos;

public sealed class CreateProductoRequest
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Nombre { get; init; } = string.Empty;

    [Range(0, 999999999)]
    public decimal Precio { get; init; }

    [Range(0, int.MaxValue)]
    public int Stock { get; init; }
}
