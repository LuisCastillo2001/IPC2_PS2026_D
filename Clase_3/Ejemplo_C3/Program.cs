using System;

namespace Clase_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║  EJEMPLOS DE LECTURA Y ESCRITURA XML EN C# ║");
            Console.WriteLine("╚════════════════════════════════════════════╝\n");

            // ============ LECTURA XML ============
            Console.WriteLine("┌─ LECTURA DE XML ─────────────────────────┐\n");

            // Ejemplo 1: XmlDocument
            EjemploXmlDocument.LeerXML();

            // Ejemplo 2: XDocument (LINQ to XML)
            EjemploXDocument.LeerXML();

            // Ejemplo 3: XPathNavigator
            EjemploXPathNavigator.LeerXML();

            Console.WriteLine("\n└──────────────────────────────────────────┘\n");

            // ============ ESCRITURA XML ============
            Console.WriteLine("┌─ ESCRITURA DE XML ───────────────────────┐\n");

            // Ejemplo 1: XmlDocument - Escritura
            EjemploXmlDocument.EscribirXML();

            // Ejemplo 2: XDocument - Escritura
            EjemploXDocument.EscribirXML();

            // Ejemplo 3: XPathNavigator - Escritura
            EjemploXPathNavigator.EscribirXML();

            Console.WriteLine("\n└──────────────────────────────────────────┘\n");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
