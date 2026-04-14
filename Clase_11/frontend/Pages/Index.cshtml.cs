using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory httpClientFactory;

    public int TotalClientes { get; set; } = 0;
    public int TotalFacturas { get; set; } = 0;

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        await CargarDatos();
    }

    private async Task CargarDatos()
    {
        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");

            List<dynamic> clientes = await client.GetFromJsonAsync<List<dynamic>>("clientes") ?? new List<dynamic>();
            TotalClientes = clientes.Count;

            List<dynamic> facturas = await client.GetFromJsonAsync<List<dynamic>>("facturas") ?? new List<dynamic>();
            TotalFacturas = facturas.Count;
        }
        catch
        {
            TotalClientes = 0;
            TotalFacturas = 0;
        }
    }
}
