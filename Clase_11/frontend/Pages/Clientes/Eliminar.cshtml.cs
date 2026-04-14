using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Clientes;

public class EliminarModel : PageModel
{
    private readonly IHttpClientFactory httpClientFactory;

    public EliminarModel(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");
            HttpResponseMessage response = await client.DeleteAsync($"clientes/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Cliente eliminado correctamente";
            }
            else
            {
                TempData["Error"] = "Error al eliminar el cliente";
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Error de conexión: " + ex.Message;
        }

        return RedirectToPage("/Clientes/Index");
    }
}
