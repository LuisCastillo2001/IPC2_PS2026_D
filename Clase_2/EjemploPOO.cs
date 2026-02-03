using System;

namespace EjemploPOO
{
    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Ejemplo de POO en C# ===\n");

            // Crear objetos
            Perro perro = new Perro("Max", 3, "Labrador");
            Gato gato = new Gato("Luna", 2, "Blanco");

            // POLIMORFISMO: Usar referencia de clase base
            Animal animal1 = perro;
            Animal animal2 = gato;

            Console.WriteLine("--- Información de las mascotas ---");
            animal1.MostrarInfo();
            animal1.HacerSonido();
            perro.Jugar();

            Console.WriteLine();

            animal2.MostrarInfo();
            animal2.HacerSonido();
            gato.Dormir();

            Console.WriteLine("\n--- Modificando datos (Encapsulamiento) ---");
            perro.SetNombre("Maximus");
            perro.SetEdad(4);
            perro.MostrarInfo();

            Console.ReadKey();
        }
    }
}
