using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase_8.Pages;

public class IndexModel : PageModel
{
    public string Mensaje { get; set; } = string.Empty;

    public void OnGet()
    {
        Mensaje = "Bienvenido al Sistema de Drones";
    }
}