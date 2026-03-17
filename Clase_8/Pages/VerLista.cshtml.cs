using Microsoft.AspNetCore.Mvc.RazorPages;
using Clase_8.Models;
using Clase_8.Servicios;

namespace Clase_8.Pages;

public class VerListaModel : PageModel
{
    private readonly ListaEnlazadaService listaEnlazadaService;

    public Nodo Raiz { get; set; }

    public string TextoLista { get; set; } = string.Empty;

    public VerListaModel(ListaEnlazadaService listaEnlazadaService)
    {
        this.listaEnlazadaService = listaEnlazadaService;
    }

    public void OnGet()
    {
        Raiz = listaEnlazadaService.Lista.Raiz;
        TextoLista = listaEnlazadaService.Imprimir();
    }
}
