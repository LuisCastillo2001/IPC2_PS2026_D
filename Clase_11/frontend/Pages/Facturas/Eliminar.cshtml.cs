using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Facturas;

public class EliminarFacturaModel : PageModel
{
    private readonly IHttpClientFactory httpClientFactory;

    public EliminarFacturaModel(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");
            HttpResponseMessage response = await client.DeleteAsync($"facturas/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Factura eliminada correctamente";
            }
            else
            {
                TempData["Error"] = "Error al eliminar la factura";
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Error de conexión: " + ex.Message;
        }

        return RedirectToPage("/Facturas/Index");
    }
}
