using System.Xml.Linq;
using Clase_8.Estructuras;
using Clase_8.Models;

namespace Clase_8.Servicios;

public class XmlParserService
{
    public class ConfiguracionDrones
    {
        public ListaDronesNombres Drones { get; set; }
        public ListaSistemasDrones Sistemas { get; set; }

        public ConfiguracionDrones()
        {
            Drones = new ListaDronesNombres();
            Sistemas = new ListaSistemasDrones();
        }
    }

    public ConfiguracionDrones ParsingXml(string rutaArchivo)
    {
        var config = new ConfiguracionDrones();

        try
        {
            if (!File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException($"Archivo no encontrado: {rutaArchivo}");
            }

            XDocument doc = XDocument.Load(rutaArchivo);
            XElement root = doc.Root;

            // Parsear lista de drones
            var nodosDrones = root.Element("listaDrones")?.Elements("dron");
            if (nodosDrones != null)
            {
                foreach (var nodo in nodosDrones)
                {
                    config.Drones.Agregar(nodo.Value.Trim());
                }
            }

            // Parsear lista de sistemas de drones
            var nodosSistemas = root.Element("listaSistemasDrones")?.Elements("sistemaDrones");
            if (nodosSistemas != null)
            {
                foreach (var sistemaNodo in nodosSistemas)
                {
                    string nombreSistema = sistemaNodo.Attribute("nombre")?.Value;
                    int alturaMaxima = int.Parse(sistemaNodo.Element("alturaMaxima")?.Value ?? "0");
                    int cantidadDrones = int.Parse(sistemaNodo.Element("cantidadDrones")?.Value ?? "0");

                    var sistema = new SistemaDrones(nombreSistema, alturaMaxima);
                    sistema.CantidadDrones = cantidadDrones;

                    var contenidos = sistemaNodo.Elements("contenido");
                    foreach (var contenido in contenidos)
                    {
                        string nombreDron = contenido.Element("dron")?.Value.Trim();
                        var alturas = contenido.Element("alturas")?.Elements("altura");
                        
                        if (alturas != null)
                        {
                            foreach (var altura in alturas)
                            {
                                int valorAltura = int.Parse(altura.Attribute("valor")?.Value ?? "0");
                                string letra = altura.Value.Trim();
                                sistema.AgregarAltura(valorAltura, nombreDron, letra);
                            }
                        }
                    }

                    config.Sistemas.Agregar(sistema);
                }
            }

            return config;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al parsear XML: {ex.Message}", ex);
        }
    }
}
