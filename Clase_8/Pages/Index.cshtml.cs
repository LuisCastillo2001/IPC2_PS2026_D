using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Clase_8.Models;
using Clase_8.Servicios;

namespace Clase_8.Pages;

public class IndexModel : PageModel
{
    private readonly ListaEnlazadaService listaEnlazadaService;

    [BindProperty]
    public string Titulo { get; set; } = string.Empty;

    [BindProperty]
    public string Director { get; set; } = string.Empty;

    [BindProperty]
    public int Anio { get; set; }

    public string Mensaje { get; set; } = string.Empty;

    public string TextoLista { get; set; } = string.Empty;

    public Nodo Raiz { get; set; }

    public IndexModel(ListaEnlazadaService listaEnlazadaService)
    {
        this.listaEnlazadaService = listaEnlazadaService;
    }

    public void OnGet()
    {
        CargarDatos();
    }

    public void OnPostAgregar()
    {
        if (Titulo.Trim() == string.Empty || Director.Trim() == string.Empty || Anio <= 0)
        {
            Mensaje = "Completa titulo, director y anio valido.";
            CargarDatos();
            return;
        }

        listaEnlazadaService.Agregar(Titulo.Trim(), Director.Trim(), Anio);
        Mensaje = "Pelicula agregada.";
        Titulo = string.Empty;
        Director = string.Empty;
        Anio = 0;
        CargarDatos();
    }

    public void OnPostEliminarUltimo()
    {
        bool eliminado = listaEnlazadaService.EliminarUltimo();
        if (eliminado)
        {
            Mensaje = "Se elimino el ultimo nodo.";
        }
        else
        {
            Mensaje = "La lista esta vacia.";
        }

        CargarDatos();
    }

    public void OnPostLimpiar()
    {
        listaEnlazadaService.Limpiar();
        Mensaje = "Lista reiniciada.";
        CargarDatos();
    }

    private void CargarDatos()
    {
        Raiz = listaEnlazadaService.Lista.Raiz;
        TextoLista = listaEnlazadaService.Imprimir();

    }
}
