using System;

namespace Clase_6
{
    // Implementación de Cola (FIFO - First In First Out)
    public class Cola
    {
        private Nodo frente;
        private Nodo fin;
        private int tamano;

        public Cola()
        {
            frente = null;
            fin = null;
            tamano = 0;
        }

        // Enqueue: Insertar un nuevo elemento al final de la cola
        public void Enqueue(int elemento)
        {
            Nodo nuevoNodo = new Nodo(elemento);

            if (IsEmpty())
            {
                frente = nuevoNodo;
                fin = nuevoNodo;
            }
            else
            {
                fin.Siguiente = nuevoNodo;
                fin = nuevoNodo;
            }

            tamano++;
            Console.WriteLine($"Enqueue: {elemento} agregado a la cola");
        }

        // Dequeue: Retirar el elemento que está al frente de la cola
        public int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Error: La cola está vacía, no se puede hacer Dequeue");
                return -1; // Valor por defecto para indicar error
            }

            int dato = frente.Dato;
            frente = frente.Siguiente;

            if (frente == null) // La cola se quedó vacía
            {
                fin = null;
            }

            tamano--;
            Console.WriteLine($"Dequeue: {dato} removido de la cola");
            return dato;
        }

        // Peek (Front): Consultar el elemento que está al frente sin retirarlo
        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Error: La cola está vacía, no hay elemento al frente");
                return -1; // Valor por defecto para indicar error
            }

            Console.WriteLine($"Peek: El elemento al frente es {frente.Dato}");
            return frente.Dato;
        }

        // IsEmpty: Verificar si la cola está vacía
        public bool IsEmpty()
        {
            return frente == null;
        }

        // Size: Obtener la cantidad de elementos en la cola
        public int Size()
        {
            return tamano;
        }

        // Método para mostrar todos los elementos de la cola
        public void MostrarCola()
        {
            if (IsEmpty())
            {
                Console.WriteLine("La cola está vacía");
                return;
            }

            Console.Write("Cola (de frente a fin): ");
            Nodo actual = frente;
            while (actual != null)
            {
                Console.Write($"{actual.Dato} ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }
}