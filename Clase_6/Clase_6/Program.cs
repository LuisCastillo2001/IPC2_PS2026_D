using System;

namespace Clase_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMOSTRACIÓN DE PILA (LIFO) ===");
            Console.WriteLine();

            // Crear una nueva pila
            Pila pila = new Pila();

            // Verificar si está vacía
            Console.WriteLine($"¿Pila vacía? {pila.IsEmpty()}");
            Console.WriteLine($"Tamaño inicial: {pila.Size()}");
            Console.WriteLine();

            // Operaciones Push (Apilar)
            pila.Push(10);
            pila.Push(20);
            pila.Push(30);
            pila.Push(40);
            Console.WriteLine();

            // Mostrar estado actual de la pila
            pila.MostrarPila();
            Console.WriteLine($"Tamaño actual: {pila.Size()}");
            Console.WriteLine();

            // Operación Peek (Consultar tope)
            pila.Peek();
            Console.WriteLine();

            // Operaciones Pop (Desapilar)
            pila.Pop();
            pila.Pop();
            pila.MostrarPila();
            Console.WriteLine($"Tamaño después de Pop: {pila.Size()}");
            Console.WriteLine();

            Console.WriteLine("=================");
            Console.WriteLine("=== DEMOSTRACIÓN DE COLA (FIFO) ===");
            Console.WriteLine();

            // Crear una nueva cola
            Cola cola = new Cola();

            // Verificar si está vacía
            Console.WriteLine($"¿Cola vacía? {cola.IsEmpty()}");
            Console.WriteLine($"Tamaño inicial: {cola.Size()}");
            Console.WriteLine();

            // Operaciones Enqueue (Encolar)
            cola.Enqueue(100);
            cola.Enqueue(200);
            cola.Enqueue(300);
            cola.Enqueue(400);
            Console.WriteLine();

            // Mostrar estado actual de la cola
            cola.MostrarCola();
            Console.WriteLine($"Tamaño actual: {cola.Size()}");
            Console.WriteLine();

            // Operación Peek (Consultar frente)
            cola.Peek();
            Console.WriteLine();

            // Operaciones Dequeue (Desencolar)
            cola.Dequeue();
            cola.Dequeue();
            cola.MostrarCola();
            Console.WriteLine($"Tamaño después de Dequeue: {cola.Size()}");
            Console.WriteLine();

            Console.WriteLine("=== COMPARACIÓN PILA vs COLA ===");
            Console.WriteLine();

            // Ejemplo comparativo
            Pila pilaEjemplo = new Pila();
            Cola colaEjemplo = new Cola();

            // Agregar los mismos elementos a ambas estructuras
            Console.WriteLine("Agregando elementos 1, 2, 3, 4 a ambas estructuras:");
            for (int i = 1; i <= 4; i++)
            {
                pilaEjemplo.Push(i);
                colaEjemplo.Enqueue(i);
            }
            Console.WriteLine();

            Console.WriteLine("Extrayendo elementos de la PILA (LIFO):");
            while (!pilaEjemplo.IsEmpty())
            {
                pilaEjemplo.Pop();
            }
            Console.WriteLine();

            Console.WriteLine("Extrayendo elementos de la COLA (FIFO):");
            while (!colaEjemplo.IsEmpty())
            {
                colaEjemplo.Dequeue();
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
