using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Facturas;

public class ClienteSelectItem
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}

public class LineaFacturaRequest
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

public class FacturaRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("clienteId")]
    public int ClienteId { get; set; }

    [JsonPropertyName("cliente")]
    public object Cliente { get; set; } = null;

    [JsonPropertyName("fecha")]
    public DateTime Fecha { get; set; }

    [JsonPropertyName("total")]
    public decimal Total { get; set; }

    [JsonPropertyName("lineas")]
    public List<LineaFacturaRequest> Lineas { get; set; } = new List<LineaFacturaRequest>();
}

public class FacturaResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("clienteId")]
    public int ClienteId { get; set; }

    [JsonPropertyName("cliente")]
    public object Cliente { get; set; }

    [JsonPropertyName("fecha")]
    public DateTime Fecha { get; set; }

    [JsonPropertyName("total")]
    public decimal Total { get; set; }

    [JsonPropertyName("lineas")]
    public List<object> Lineas { get; set; } = new List<object>();
}

public class CrearFacturaModel : PageModel
{
    private readonly IHttpClientFactory httpClientFactory;

    public List<ClienteSelectItem> Clientes { get; set; } = new List<ClienteSelectItem>();
    public string Error { get; set; } = string.Empty;

    [BindProperty]
    public int ClienteId { get; set; }

    [BindProperty]
    public DateTime Fecha { get; set; } = DateTime.Now;

    public CrearFacturaModel(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        await CargarClientes();
    }

    private async Task CargarClientes()
    {
        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");
            Clientes = await client.GetFromJsonAsync<List<ClienteSelectItem>>("clientes") ?? new List<ClienteSelectItem>();
        }
        catch (Exception ex)
        {
            Error = "Error al cargar los clientes: " + ex.Message;
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ClienteId <= 0)
        {
            Error = "Debe seleccionar un cliente";
            await CargarClientes();
            return Page();
        }

        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");

            var nuevaFactura = new FacturaRequest
            {
                Id = 0,
                ClienteId = ClienteId,
                Cliente = null,
                Fecha = Fecha,
                Total = 0m,
                Lineas = new List<LineaFacturaRequest>()
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("facturas", nuevaFactura);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var facturaCreada = await response.Content.ReadFromJsonAsync<FacturaResponse>();
                    
                    if (facturaCreada != null && facturaCreada.Id > 0)
                    {
                        return RedirectToPage("/Facturas/Detalles", new { id = facturaCreada.Id });
                    }
                    else
                    {
                        Error = "La factura se creó pero no se obtuvo un ID válido";
                    }
                }
                catch (Exception parseEx)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Error = $"Error al procesar la respuesta: {parseEx.Message}. Contenido: {content}";
                }
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Error = $"Error al crear la factura (Código {response.StatusCode}): {errorContent}";
            }
        }
        catch (Exception ex)
        {
            Error = "Error de conexión: " + ex.Message;
        }

        await CargarClientes();
        return Page();
    }
}
