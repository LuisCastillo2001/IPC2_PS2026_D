using System;

namespace EjemploPOO
{
    // HERENCIA: Perro hereda de Animal
    public class Perro : Animal
    {
        private string raza;

        public Perro(string nombre, int edad, string raza) : base(nombre, edad)
        {
            this.raza = raza;
        }

        // Métodos Get y Set para raza
        public string GetRaza()
        {
            return raza;
        }

        public void SetRaza(string raza)
        {
            this.raza = raza;
        }

        // POLIMORFISMO: Implementación específica del método abstracto
        public override void HacerSonido()
        {
            Console.WriteLine($"{GetNombre()} dice: ¡Guau guau!");
        }

        public void Jugar()
        {
            Console.WriteLine($"{GetNombre()} está jugando con la pelota");
        }
    }
}
