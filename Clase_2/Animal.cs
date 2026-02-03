using System;

namespace EjemploPOO
{
    // ABSTRACCIÓN: Clase abstracta que define el comportamiento básico
    public abstract class Animal
    {
        // ENCAPSULAMIENTO: Campos privados
        private string nombre;
        private int edad;

        // Constructor
        public Animal(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        // Métodos Get y Set para nombre
        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        // Métodos Get y Set para edad
        public int GetEdad()
        {
            return edad;
        }

        public void SetEdad(int edad)
        {
            if (edad >= 0)
            {
                this.edad = edad;
            }
        }

        // Método concreto
        public void MostrarInfo()
        {
            Console.WriteLine($"Nombre: {nombre}, Edad: {edad} años");
        }

        // ABSTRACCIÓN: Método abstracto que las clases hijas deben implementar
        public abstract void HacerSonido();
    }
}
