using System;
using System.Xml;

namespace Clase_3
{
    /// <summary>
    /// Ejemplo de lectura XML usando XmlDocument (DOM - Document Object Model)
    /// Ventajas: Acceso aleatorio a cualquier nodo, modificación fácil
    /// Desventajas: Carga todo el documento en memoria
    /// </summary>
    public class EjemploXmlDocument
    {
        public static void LeerXML()
        {
            Console.WriteLine("=== Ejemplo XmlDocument ===\n");

            // Crear una instancia de XmlDocument
            XmlDocument doc = new XmlDocument();

            try
            {
                // Cargar el archivo XML
                doc.Load("estudiantes.xml");

                // Obtener el nodo raíz
                XmlNode raiz = doc.DocumentElement;
                Console.WriteLine($"Nodo raíz: {raiz.Name}\n");

                // Obtener todos los estudiantes
                XmlNodeList estudiantes = doc.GetElementsByTagName("estudiante");

                Console.WriteLine($"Total de estudiantes: {estudiantes.Count}\n");

                // Iterar sobre cada estudiante
                foreach (XmlNode estudiante in estudiantes)
                {
                    // Leer atributos
                    string id = estudiante.Attributes["id"].Value;
                    string carnet = estudiante.Attributes["carnet"].Value;
                    
                    Console.WriteLine($"ID: {id}");
                    Console.WriteLine($"Carnet: {carnet}");

                    // Leer elementos hijos
                    string nombre = estudiante.SelectSingleNode("nombre").InnerText;
                    string carrera = estudiante.SelectSingleNode("carrera").InnerText;
                    string promedio = estudiante.SelectSingleNode("promedio").InnerText;

                    Console.WriteLine($"Nombre: {nombre}");
                    Console.WriteLine($"Carrera: {carrera}");
                    Console.WriteLine($"Promedio: {promedio}");
                    Console.WriteLine("------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void EscribirXML()
        {
            Console.WriteLine("\n=== Ejemplo XmlDocument - ESCRITURA ===\n");

            try
            {
                // Crear un nuevo documento XML
                XmlDocument doc = new XmlDocument();

                // Agregar la declaración XML
                XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(declaracion);

                // Crear el elemento raíz
                XmlElement universidad = doc.CreateElement("universidad");
                doc.AppendChild(universidad);

                // Crear el contenedor de estudiantes
                XmlElement estudiantes = doc.CreateElement("estudiantes");
                universidad.AppendChild(estudiantes);

                // Agregar estudiante 1
                XmlElement estudiante1 = doc.CreateElement("estudiante");
                estudiante1.SetAttribute("id", "1");
                estudiante1.SetAttribute("carnet", "3456");

                XmlElement nombre1 = doc.CreateElement("nombre");
                nombre1.InnerText = "Ana Martínez";
                estudiante1.AppendChild(nombre1);

                XmlElement carnet1 = doc.CreateElement("carnet");
                carnet1.InnerText = "202112345";
                estudiante1.AppendChild(carnet1);

                XmlElement carrera1 = doc.CreateElement("carrera");
                carrera1.InnerText = "Ingeniería Mecánica";
                estudiante1.AppendChild(carrera1);

                XmlElement promedio1 = doc.CreateElement("promedio");
                promedio1.InnerText = "92.5";
                estudiante1.AppendChild(promedio1);

                estudiantes.AppendChild(estudiante1);

                // Agregar estudiante 2
                XmlElement estudiante2 = doc.CreateElement("estudiante");
                estudiante2.SetAttribute("id", "2");
                estudiante2.SetAttribute("carnet", "7890");

                XmlElement nombre2 = doc.CreateElement("nombre");
                nombre2.InnerText = "Pedro Ramírez";
                estudiante2.AppendChild(nombre2);

                XmlElement carnet2 = doc.CreateElement("carnet");
                carnet2.InnerText = "202112346";
                estudiante2.AppendChild(carnet2);

                XmlElement carrera2 = doc.CreateElement("carrera");
                carrera2.InnerText = "Ingeniería Química";
                estudiante2.AppendChild(carrera2);

                XmlElement promedio2 = doc.CreateElement("promedio");
                promedio2.InnerText = "87.8";
                estudiante2.AppendChild(promedio2);

                estudiantes.AppendChild(estudiante2);

                // Guardar el documento con formato
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "  ";
                settings.NewLineChars = "\n";

                using (XmlWriter writer = XmlWriter.Create("estudiantes_nuevos_xmldocument.xml", settings))
                {
                    doc.Save(writer);
                }

                Console.WriteLine("Archivo 'estudiantes_nuevos_xmldocument.xml' creado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
