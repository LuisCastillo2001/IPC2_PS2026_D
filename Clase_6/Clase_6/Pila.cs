using System;

namespace Clase_6
{
    // Implementación de Pila (LIFO - Last In First Out)
    public class Pila
    {
        private Nodo tope;
        private int tamano;

        public Pila()
        {
            tope = null;
            tamano = 0;
        }

        // Push: Apilar o insertar un nuevo elemento en la parte superior de la pila
        public void Push(int elemento)
        {
            Nodo nuevoNodo = new Nodo(elemento);
            nuevoNodo.Siguiente = tope;
            tope = nuevoNodo;
            tamano++;
            Console.WriteLine($"Push: {elemento} agregado a la pila");
        }

        // Pop: Desapilar o eliminar el elemento que está en la parte superior de la pila
        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Error: La pila está vacía, no se puede hacer Pop");
                return -1; // Valor por defecto para indicar error
            }

            int dato = tope.Dato;
            tope = tope.Siguiente;
            tamano--;
            Console.WriteLine($"Pop: {dato} removido de la pila");
            return dato;
        }

        // Peek (Top): Consultar el elemento que está en la parte superior sin eliminarlo
        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Error: La pila está vacía, no hay elemento en el tope");
                return -1; // Valor por defecto para indicar error
            }

            Console.WriteLine($"Peek: El elemento en el tope es {tope.Dato}");
            return tope.Dato;
        }

        // IsEmpty: Verificar si la pila está vacía
        public bool IsEmpty()
        {
            return tope == null;
        }

        // Size: Obtener la cantidad de elementos en la pila
        public int Size()
        {
            return tamano;
        }

        // Método para mostrar todos los elementos de la pila
        public void MostrarPila()
        {
            if (IsEmpty())
            {
                Console.WriteLine("La pila está vacía");
                return;
            }

            Console.Write("Pila (de tope a fondo): ");
            Nodo actual = tope;
            while (actual != null)
            {
                Console.Write($"{actual.Dato} ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }
}