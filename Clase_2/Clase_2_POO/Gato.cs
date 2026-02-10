using System;

namespace EjemploPOO

{
    public class Gato : Animal
    {
        private string color;

        public Gato(string nombre, int edad, string color) : base(nombre, edad)
        {
            this.color = color;
        }

        public string GetColor()
        {
            return color;
        }

        public void SetColor(string color)
        {
            this.color = color;
        }

        // POLIMORFISMO

        public override void HacerSonido()
        {
            Console.WriteLine($"{GetNombre()}, dice: Miau");
        }

        public void Dormir()
        {
            Console.WriteLine($"{GetNombre()} esta durmiendo tranquilamente");
        }

    }
}