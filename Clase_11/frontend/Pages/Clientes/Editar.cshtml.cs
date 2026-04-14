using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Clientes;

public class EditarClienteModel : PageModel
{
    private readonly IHttpClientFactory httpClientFactory;

    public int Id { get; set; }
    public string Error { get; set; } = string.Empty;

    [BindProperty]
    public string Nombre { get; set; } = string.Empty;

    [BindProperty]
    public string Correo { get; set; } = string.Empty;

    [BindProperty]
    public string Telefono { get; set; } = string.Empty;

    [BindProperty]
    public string Direccion { get; set; } = string.Empty;

    public EditarClienteModel(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync(int id)
    {
        Id = id;
        await CargarCliente(id);
    }

    private async Task CargarCliente(int id)
    {
        try
        {
            HttpClient client = httpClientFactory.CreateClient("ApiClient");
            ClienteItem cliente = await client.GetFromJsonAsync<ClienteItem>($"clientes/{id}");

            if (cliente != null)
            {
                Nombre = cliente.Nombre;
                Correo = cliente.Correo;
                Telefono = cliente.Telefono;
                Direccion = cliente.Direccion;
            }
            else
            {
                Error = "Cliente no encontrado";
            }
        }
        catch (Exception ex)
        {
            Error = "Error al cargar el cliente: " + ex.Message;
        }
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

            var clienteActualizado = new
            {
                nombre = Nombre,
                correo = Correo,
                telefono = Telefono,
                direccion = Direccion
            };

            HttpResponseMessage response = await client.PutAsJsonAsync($"clientes/{Id}", clienteActualizado);

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Cliente actualizado correctamente";
                return RedirectToPage("/Clientes/Index");
            }
            else
            {
                Error = "Error al actualizar el cliente";
            }
        }
        catch (Exception ex)
        {
            Error = "Error de conexión: " + ex.Message;
        }

        return Page();
    }
}
