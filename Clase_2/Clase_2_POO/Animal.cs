using System;

namespace EjemploPOO
{
    // ABSTRACCIÓN: Clase abstracta que define el comportamiento básico

    public abstract class Animal
    {
        //Encapsulamiento : Campos privados
        private string nombre;
        private int edad;

        // Constructor
        public Animal(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        // Metodos get y set para nombre
        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        // Metodos get y set para edad

        public int GetEdad()
        {
            return edad;
        }
        public void SetEdad( int edad)
        {
            if(edad >= 0)
            {
                this.edad = edad;
            }
        }

        //Metodo concreto
        public void MostrarInfo()
        {
            Console.WriteLine($"Nombre: {nombre}, Edad: {edad} años ");
        }

        // Metodo abstracto que todas las clases hijas van ha tener

        public abstract void HacerSonido();

    }
}