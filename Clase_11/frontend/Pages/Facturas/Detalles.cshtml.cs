using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Facturas;

public class LineaFacturaItem
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

public class ClienteDetalleItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
}

public class LineaDetalleRespuesta
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty;

    [JsonPropertyName("cantidad")]
    public int Cantidad { get; set; }

    [JsonPropertyName("precioUnitario")]
    public decimal PrecioUnitario { get; set; }
}

public class FacturaDetalleRespuesta
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("clienteId")]
    public int ClienteId { get; set; }

    [JsonPropertyName("cliente")]
    public ClienteDetalleItem Cliente { get; set; } = new ClienteDetalleItem();

    [JsonPropertyName("fecha")]
    public DateTime Fecha { get; set; }

    [JsonPropertyName("total")]
    public decimal Total { get; set; }

    [JsonPropertyName("lineas")]
    public List<LineaDetalleRespuesta> Lineas { get; set; } = new List<LineaDetalleRespuesta>();
}

public class AgregarLineaRequest
{
    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty;

    [JsonPropertyName("cantidad")]
    public int Cantidad { get; set; }

    [JsonPropertyName("precioUnitario")]
    public decimal PrecioUnitario { get; set; }
}

public class DetallesFacturaModel : PageModel
{
    private readonly IHttpClientFactory httpClientFactory;

    public int Id { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public List<LineaFacturaItem> Lineas { get; set; } = new List<LineaFacturaItem>();
    public string Error { get; set; } = string.Empty;

    [BindProperty]
    public string Descripcion { get; set; } = string.Empty;

    [BindProperty]
    public int Cantidad { get; set; }

    [BindProperty]
    public decimal PrecioUnitario { get; set; }

    public DetallesFacturaModel(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync(int id)
    {
        Id = id;
        await CargarFactura(id);
    }

    private async Task CargarFactura(int id)
    {
        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");
            var facturaRespuesta = await client.GetFromJsonAsync<FacturaDetalleRespuesta>($"facturas/{id}");

            if (facturaRespuesta != null)
            {
                Id = facturaRespuesta.Id;
                NombreCliente = facturaRespuesta.Cliente.Nombre;
                Fecha = facturaRespuesta.Fecha;
                Total = facturaRespuesta.Total;
                Lineas = facturaRespuesta.Lineas.Select(l => new LineaFacturaItem
                {
                    Id = l.Id,
                    Descripcion = l.Descripcion,
                    Cantidad = l.Cantidad,
                    PrecioUnitario = l.PrecioUnitario
                }).ToList();
            }
            else
            {
                Error = "Factura no encontrada";
            }
        }
        catch (Exception ex)
        {
            Error = "Error al cargar la factura: " + ex.Message;
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Descripcion) || Cantidad <= 0 || PrecioUnitario <= 0)
        {
            Error = "Todos los campos son requeridos y deben ser válidos";
            await CargarFactura(Id);
            return Page();
        }

        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");

            var nuevaLinea = new AgregarLineaRequest
            {
                Descripcion = Descripcion,
                Cantidad = Cantidad,
                PrecioUnitario = PrecioUnitario
            };

            HttpResponseMessage response = await client.PostAsJsonAsync($"facturas/{Id}/lineas", nuevaLinea);

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Línea agregada correctamente";
                Descripcion = string.Empty;
                Cantidad = 0;
                PrecioUnitario = 0m;
                return RedirectToPage(new { id = Id });
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Error = $"Error al agregar la línea (Código {response.StatusCode}): {errorContent}";
            }
        }
        catch (Exception ex)
        {
            Error = "Error de conexión: " + ex.Message;
        }

        await CargarFactura(Id);
        return Page();
    }
}
