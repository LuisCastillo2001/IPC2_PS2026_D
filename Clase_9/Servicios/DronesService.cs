using Clase_8.Estructuras;
using Clase_8.Models;

namespace Clase_8.Servicios;

public class DronesService
{
    private ListaDrones listaDrones;
    private ListaSistemasDrones sistemas;

    public DronesService()
    {
        listaDrones = new ListaDrones();
        sistemas = new ListaSistemasDrones();
    }

    public void CargarDesdeXml(string rutaArchivo)
    {
        var parser = new XmlParserService();
        var config = parser.ParsingXml(rutaArchivo);

        listaDrones.Limpiar();
        sistemas.Limpiar();

        // Agregar drones a la lista
        var nodoDron = config.Drones.Raiz;
        while (nodoDron != null)
        {
            var dron = new Dron(nodoDron.NombreDron, 100);
            listaDrones.Agregar(dron);
            nodoDron = nodoDron.Siguiente;
        }

        // Agregar sistemas
        var nodoSistema = config.Sistemas.Raiz;
        while (nodoSistema != null)
        {
            sistemas.Agregar(nodoSistema.Sistema);
            nodoSistema = nodoSistema.Siguiente;
        }
    }

    public ListaDrones ObtenerListaDrones()
    {
        return listaDrones;
    }

    public ListaSistemasDrones ObtenerSistemas()
    {
        return sistemas;
    }

    public void SubirDron(string nombreDron)
    {
        var dron = listaDrones.ObtenerDron(nombreDron);
        if (dron != null && dron.AlturaActual < dron.AlturaMaxima)
        {
            dron.AlturaActual++;
        }
    }

    public void BajarDron(string nombreDron)
    {
        var dron = listaDrones.ObtenerDron(nombreDron);
        if (dron != null && dron.AlturaActual > 0)
        {
            dron.AlturaActual--;
        }
    }

    public void EncenderLuz(string nombreDron)
    {
        var dron = listaDrones.ObtenerDron(nombreDron);
        if (dron != null)
        {
            dron.LuzActiva = true;
        }
    }

    public void ApagarLuz(string nombreDron)
    {
        var dron = listaDrones.ObtenerDron(nombreDron);
        if (dron != null)
        {
            dron.LuzActiva = false;
        }
    }

    public string ObtenerEstadoCompleto()
    {
        return listaDrones.Listar();
    }

    public string GenerarGraphviz()
    {
        var graphviz = new GraphvizService();
        return graphviz.GenerarDiagrama(listaDrones);
    }
}
