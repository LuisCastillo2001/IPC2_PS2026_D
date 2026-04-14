using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Clientes;

public class CrearClienteModel : PageModel
{
    private readonly IHttpClientFactory httpClientFactory;

    public string Error { get; set; } = string.Empty;

    [BindProperty]
    public string Nombre { get; set; } = string.Empty;

    [BindProperty]
    public string Correo { get; set; } = string.Empty;

    [BindProperty]
    public string Telefono { get; set; } = string.Empty;

    [BindProperty]
    public string Direccion { get; set; } = string.Empty;

    public CrearClienteModel(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Nombre))
        {
            Error = "El nombre es requerido";
            return Page();
        }

        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");

            var nuevoCliente = new
            {
                nombre = Nombre,
                correo = Correo,
                telefono = Telefono,
                direccion = Direccion
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("clientes", nuevoCliente);

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Cliente creado correctamente";
                return RedirectToPage("/Clientes/Index");
            }
            else
            {
                Error = "Error al crear el cliente. Intenta nuevamente";
            }
        }
        catch (Exception ex)
        {
            Error = "Error de conexión: " + ex.Message;
        }

        return Page();
    }
}
