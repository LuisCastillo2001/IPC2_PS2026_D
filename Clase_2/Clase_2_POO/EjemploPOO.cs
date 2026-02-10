using System;

namespace EjemploPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Crear un objeto perro
            Perro perro = new Perro("Max", 3, "Labrador");
            Gato gato = new Gato("Luna", 2, "Blanco");

            //Animal animal1 = perro;

            Console.WriteLine("-----Informacion de las mascostas--------");
            perro.MostrarInfo();
            perro.HacerSonido();
            perro.Jugar();


            Console.WriteLine();

            gato.MostrarInfo();
            gato.HacerSonido();
            gato.Dormir();

            gato.SetEdad(10);
            Console.WriteLine(gato.GetEdad());




        }
    }
}