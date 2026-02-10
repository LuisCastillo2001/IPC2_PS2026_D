using System;
using System.Xml;
using System.Xml.XPath;

namespace Clase_3
{
    /// <summary>
    /// Ejemplo de lectura y escritura XML usando XPathNavigator
    /// Ventajas: Búsquedas complejas con XPath, navegación eficiente
    /// Nota: XPathDocument es solo lectura, para escritura usamos XmlDocument
    /// </summary>
    public class EjemploXPathNavigator
    {
        public static void LeerXML()
        {
            Console.WriteLine("\n=== Ejemplo XPathNavigator - LECTURA ===\n");

            try
            {
                XPathDocument doc = new XPathDocument("estudiantes.xml");
                XPathNavigator navigator = doc.CreateNavigator();

                XPathNodeIterator estudiantes = navigator.Select("//estudiante");
                Console.WriteLine($"Total de estudiantes: {estudiantes.Count}\n");

                while (estudiantes.MoveNext())
                {
                    XPathNavigator estudianteNav = estudiantes.Current;

                    // Leer atributos
                    string id = estudianteNav.GetAttribute("id", "");
                    string carnet = estudianteNav.GetAttribute("carnet", "");
                    
                    Console.WriteLine($"ID: {id}");
                    Console.WriteLine($"Carnet: {carnet}");

                    XPathNavigator clone = estudianteNav.Clone();
                    
                    clone.MoveToChild("nombre", "");
                    string nombre = clone.Value;
                    
                    clone.MoveToParent();
                    clone.MoveToChild("carrera", "");
                    string carrera = clone.Value;
                    
                    clone.MoveToParent();
                    clone.MoveToChild("promedio", "");
                    string promedio = clone.Value;

                    Console.WriteLine($"Nombre: {nombre}");
                    Console.WriteLine($"Carrera: {carrera}");
                    Console.WriteLine($"Promedio: {promedio}");
                    Console.WriteLine("------------------------");
                }

                Console.WriteLine("\nBúsqueda con XPath - Promedio >= 88:");
                XPathNodeIterator destacados = navigator.Select("//estudiante[promedio >= 88]");
                while (destacados.MoveNext())
                {
                    string carnet = destacados.Current.GetAttribute("carnet", "");
                    string nombre = destacados.Current.SelectSingleNode("nombre").Value;
                    string promedio = destacados.Current.SelectSingleNode("promedio").Value;
                    Console.WriteLine($"[{carnet}] {nombre}: {promedio}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void EscribirXML()
        {
            Console.WriteLine("\n=== Ejemplo XPathNavigator - ESCRITURA ===\n");

            try
            {
                // XPathNavigator con escritura requiere XmlDocument
                XmlDocument doc = new XmlDocument();
                
                // Crear estructura básica
                XmlDeclaration declaracion = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(declaracion);
                
                XmlElement universidad = doc.CreateElement("universidad");
                doc.AppendChild(universidad);
                
                XmlElement estudiantes = doc.CreateElement("estudiantes");
                universidad.AppendChild(estudiantes);

                // Crear navegador para escritura
                XPathNavigator navigator = doc.CreateNavigator();
                navigator.MoveToRoot();
                navigator.MoveToFirstChild(); // Ir a universidad
                navigator.MoveToFirstChild(); // Ir a estudiantes

                // Agregar estudiante 1 usando AppendChild
                string estudianteXml1 = @"
                    <estudiante id='1' carnet='3001'>
                        <nombre>Roberto Castillo</nombre>
                        <carrera>Ingeniería Mecánica Industrial</carrera>
                        <promedio>89.5</promedio>
                    </estudiante>";
                navigator.AppendChild(estudianteXml1);

                // Agregar estudiante 2
                string estudianteXml2 = @"
                    <estudiante id='2' carnet='3002'>
                        <nombre>Gabriela Flores</nombre>
                        <carrera>Ingeniería Electrónica</carrera>
                        <promedio>93.2</promedio>
                    </estudiante>";
                navigator.AppendChild(estudianteXml2);

                // Guardar con formato
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "  ";

                using (XmlWriter writer = XmlWriter.Create("estudiantes_nuevos_xpath.xml", settings))
                {
                    doc.Save(writer);
                }

                Console.WriteLine("Archivo 'estudiantes_nuevos_xpath.xml' creado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
