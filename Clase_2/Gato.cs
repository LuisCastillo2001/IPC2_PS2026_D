using System;

namespace EjemploPOO
{
    // HERENCIA: Gato hereda de Animal
    public class Gato : Animal
    {
        private string color;

        public Gato(string nombre, int edad, string color) : base(nombre, edad)
        {
            this.color = color;
        }

        // Métodos Get y Set para color
        public string GetColor()
        {
            return color;
        }

        public void SetColor(string color)
        {
            this.color = color;
        }

        // POLIMORFISMO: Implementación específica del método abstracto
        public override void HacerSonido()
        {
            Console.WriteLine($"{GetNombre()} dice: ¡Miau miau!");
        }

        public void Dormir()
        {
            Console.WriteLine($"{GetNombre()} está durmiendo tranquilamente");
        }
    }
}
