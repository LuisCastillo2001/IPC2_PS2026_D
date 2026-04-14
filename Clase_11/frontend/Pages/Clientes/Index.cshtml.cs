using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Clientes;

public class ClienteItem
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; }
}

public class ClientesIndexModel : PageModel
{
    private readonly IHttpClientFactory httpClientFactory;

    public List<ClienteItem> Clientes { get; set; } = new List<ClienteItem>();
    public string Mensaje { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;

    public ClientesIndexModel(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        Mensaje = TempData["Mensaje"] as string;
        await CargarClientes();
    }

    private async Task CargarClientes()
    {
        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");
            Clientes = await client.GetFromJsonAsync<List<ClienteItem>>("clientes") ?? new List<ClienteItem>();
        }
        catch (Exception ex)
        {
            Error = "Error al cargar los clientes: " + ex.Message;
        }
    }
}
