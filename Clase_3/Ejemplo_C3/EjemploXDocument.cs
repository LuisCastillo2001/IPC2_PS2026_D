using System;
using System.Linq;
using System.Xml.Linq;

namespace Clase_3
{
    /// <summary>
    /// Ejemplo de lectura XML usando XDocument (LINQ to XML)
    /// Ventajas: Sintaxis más moderna, integración con LINQ, más fácil de usar
    /// Desventajas: También carga todo en memoria
    /// </summary>
    public class EjemploXDocument
    {
        public static void LeerXML()
        {
            Console.WriteLine("\n=== Ejemplo XDocument (LINQ to XML) ===\n");

            try
            {
                // Cargar el archivo XML
                XDocument doc = XDocument.Load("estudiantes.xml");

                // Obtener el elemento raíz
                XElement raiz = doc.Root;
                Console.WriteLine($"Nodo raíz: {raiz.Name}\n");

                // Método 1: Usando métodos de navegación
                var estudiantes = doc.Descendants("estudiante");
                Console.WriteLine($"Total de estudiantes: {estudiantes.Count()}\n");

                foreach (var estudiante in estudiantes)
                {
                    // Leer atributos
                    string id = estudiante.Attribute("id").Value;
                    string carnet = estudiante.Attribute("carnet").Value;
                    
                    Console.WriteLine($"ID: {id}");
                    Console.WriteLine($"Carnet: {carnet}");

                    // Leer elementos hijos
                    string nombre = estudiante.Element("nombre").Value;
                    string carrera = estudiante.Element("carrera").Value;
                    double promedio = double.Parse(estudiante.Element("promedio").Value);

                    Console.WriteLine($"Nombre: {nombre}");
                    Console.WriteLine($"Carrera: {carrera}");
                    Console.WriteLine($"Promedio: {promedio:F2}");
                    Console.WriteLine("------------------------");
                }

                // Método 2: Usando LINQ Query
                Console.WriteLine("\nEstudiantes con promedio >= 88:");
                var estudiantesDestacados = from e in doc.Descendants("estudiante")
                                           where double.Parse(e.Element("promedio").Value) >= 88
                                           select new
                                           {
                                               Carnet = e.Attribute("carnet").Value,
                                               Nombre = e.Element("nombre").Value,
                                               Promedio = e.Element("promedio").Value
                                           };

                foreach (var est in estudiantesDestacados)
                {
                    Console.WriteLine($"[{est.Carnet}] {est.Nombre} - Promedio: {est.Promedio}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void EscribirXML()
        {
            Console.WriteLine("\n=== Ejemplo XDocument (LINQ to XML) - ESCRITURA ===\n");

            try
            {
                // Construcción funcional (más compacta y elegante)
                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", null),
                    new XElement("universidad",
                        new XElement("estudiantes",
                            new XElement("estudiante",
                                new XAttribute("id", "1"),
                                new XAttribute("carnet", "2001"),
                                new XElement("nombre", "Ana Martínez"),
                                new XElement("carrera", "Ingeniería Mecánica"),
                                new XElement("promedio", "92.5")
                            ),
                            new XElement("estudiante",
                                new XAttribute("id", "2"),
                                new XAttribute("carnet", "2002"),
                                new XElement("nombre", "Pedro Ramírez"),
                                new XElement("carrera", "Ingeniería Química"),
                                new XElement("promedio", "87.8")
                            ),
                            new XElement("estudiante",
                                new XAttribute("id", "3"),
                                new XAttribute("carnet", "2003"),
                                new XElement("nombre", "Laura Sánchez"),
                                new XElement("carrera", "Ingeniería Eléctrica"),
                                new XElement("promedio", "95.0")
                            )
                        )
                    )
                );

                // Guardar con formato
                doc.Save("estudiantes_nuevos_xdocument.xml");
                Console.WriteLine("Archivo 'estudiantes_nuevos_xdocument.xml' creado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
