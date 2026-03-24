using Microsoft.AspNetCore.Mvc.RazorPages;
using Clase_8.Servicios;
using Clase_8.Estructuras;
using Clase_8.Models;

namespace Clase_8.Pages;

public class DronesModel : PageModel
{
    private readonly DronesService _dronesService;

    public string DronesInfo { get; set; } = "Cargue un archivo XML para ver la lista de drones.";
    public ListaDrones ListaDronesActual { get; set; } = new ListaDrones();
    public int TotalDrones { get; set; } = 0;
    public int TotalSistemas { get; set; } = 0;
    public string CodigoGraphviz { get; set; } = "";
    public string MensajeEstado { get; set; } = "";
    public string MensajeError { get; set; } = "";
    public bool MostrarGrafo { get; set; } = false;

    public DronesModel(DronesService dronesService)
    {
        _dronesService = dronesService;
    }

    public void OnGet()
    {
        ActualizarInformacion();
    }

    public void OnPostCargarXml(string rutaArchivo)
    {
        try
        {
            _dronesService.CargarDesdeXml(rutaArchivo);
            MensajeEstado = "Archivo XML cargado exitosamente.";
            ActualizarInformacion();
        }
        catch (Exception ex)
        {
            MensajeError = $"Error al cargar XML: {ex.Message}";
        }
    }

    public void OnPostExportarGraphviz()
    {
        try
        {
            // Crear directorio si no existe
            string directorioGrafos = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "grafos");
            if (!Directory.Exists(directorioGrafos))
            {
                Directory.CreateDirectory(directorioGrafos);
            }

            // Generar Graphviz
            string dotContent = _dronesService.GenerarGraphviz();
            string rutaImagenPng = Path.Combine(directorioGrafos, "drones_grafo.png");

            // Intentar exportar como imagen
            var graphvizService = new GraphvizService();
            graphvizService.ExportarImage(dotContent, rutaImagenPng);

            MostrarGrafo = true;
            MensajeEstado = "Grafo exportado exitosamente a PNG.";
        }
        catch
        {
            MostrarGrafo = false;
            MensajeEstado = "No se pudo exportar a imagen. Asegúrese de tener Graphviz instalado. Mostrando código DOT.";
        }

        ActualizarInformacion();
    }

    private void ActualizarInformacion()
    {
        var listaDrones = _dronesService.ObtenerListaDrones();
        var sistemas = _dronesService.ObtenerSistemas();

        ListaDronesActual = listaDrones;
        DronesInfo = _dronesService.ObtenerEstadoCompleto();
        TotalDrones = listaDrones.Contar();
        TotalSistemas = sistemas.Contar();
        CodigoGraphviz = _dronesService.GenerarGraphviz();
    }
}
