using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Facturas;

public class ClienteInfoItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
}

public class LineaItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty;
}

public class FacturaRespuesta
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("clienteId")]
    public int ClienteId { get; set; }

    [JsonPropertyName("cliente")]
    public ClienteInfoItem Cliente { get; set; } = new ClienteInfoItem();

    [JsonPropertyName("fecha")]
    public DateTime Fecha { get; set; }

    [JsonPropertyName("total")]
    public decimal Total { get; set; }

    [JsonPropertyName("lineas")]
    public List<LineaItem> Lineas { get; set; } = new List<LineaItem>();
}

public class FacturaItem
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public int CantidadLineas { get; set; }
}

public class FacturasIndexModel : PageModel
{
    private readonly IHttpClientFactory httpClientFactory;

    public List<FacturaItem> Facturas { get; set; } = new List<FacturaItem>();
    public string Mensaje { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;

    public FacturasIndexModel(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        Mensaje = TempData["Mensaje"] as string;
        await CargarFacturas();
    }

    private async Task CargarFacturas()
    {
        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");
            var facturasRespuesta = await client.GetFromJsonAsync<List<FacturaRespuesta>>("facturas") ?? new List<FacturaRespuesta>();

            Facturas = facturasRespuesta.Select(f => new FacturaItem
            {
                Id = f.Id,
                ClienteId = f.ClienteId,
                NombreCliente = f.Cliente.Nombre ?? "Sin cliente",
                Fecha = f.Fecha,
                Total = f.Total,
                CantidadLineas = f.Lineas.Count
            }).ToList();
        }
        catch (Exception ex)
        {
            Error = "Error al cargar las facturas: " + ex.Message;
        }
    }
}
