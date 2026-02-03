using System;

class Program
{
    static void Main(string[] args)
    {
        // Esto es un comentario de una linea
        /* 
        Esto es un comentario multiple linea
        */

        // Variables
        string nombre;
        int edad;
        int nota;
        double flotante = 10.20;
        bool valor = true;
        char opcion;

        Console.Write("Ingrese el nombre del estudiante: ");
        nombre = Console.ReadLine();

        Console.Write("Ingrese la nota: ");
        nota = Convert.ToInt32(Console.ReadLine());

        // Condicional if - else
                    //OR
        if (nota >= 61 || nombre == "Luis")
        {
            Console.WriteLine("Curso aprobado y el estudiante se llama Luis");
        }
        else
        {
            Console.WriteLine("Estado: Reprobado");
        }

        
        Console.WriteLine("\nSeleccione una opción: ");
        Console.WriteLine("A - Ver nota en letras");
        Console.WriteLine("B - Salir");
        opcion = Convert.ToChar(Console.ReadLine().ToUpper());

        switch (opcion)
        {
            case 'A':
                Console.WriteLine(ConvertirNota(nota));
                break;

            case 'B':
                Console.WriteLine("Seleccionaste la opcion B");
                break;

            default: 
                Console.WriteLine("Opcion no valida");
                break;
        }

        // Ciclo for 
        Console.WriteLine("\n Conteo de números hasta el 5");

        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine(i);
        }

        // Decremento
        Console.WriteLine("Decrementando una variable");
        for (int i = 5; i > 0; i--)
        {
            Console.WriteLine(i);
        }

        // Ciclo while

        int contador = 1;

        Console.WriteLine("\n Contador hasta 5");
        while (contador <= 0)
        {
            Console.WriteLine(contador);
            contador++;
            
        }

        // Ciclo do-while

        int suma = 0;
        int numero = 0;

        Console.WriteLine("Ingrese numeros para sumar (0 para terminar)");

        do
        {
            numero = Convert.ToInt32(Console.ReadLine());
            suma += numero;
        }while (numero != 0);

        Console.WriteLine($"La suma es: {suma}");

        // Leer un arreglo con for each

        string [] materias = {"Matematicas", "Ciencias", "Historia"};
        Console.WriteLine(materias.Length);
        Console.WriteLine("Materias inscritas");

        for (int i = 0; i < materias.Length; i++)
        {
            Console.WriteLine(materias[i]);
        }

        foreach (string materia in materias)
        {
            Console.WriteLine(materia);
        }

        int [,] numeros = {{1,2,3}, {4,5,6}}; 


        static void MostrarMensaje(int nota)
        {
            Console.WriteLine("La nota ingresada es de:"+nota);
        }
        Console.WriteLine("Llamando a la funcion nota");
        MostrarMensaje(12);

        static string ConvertirNota(int nota)
        {
            if(nota >= 90)
            {
                return "Excelente";
            }else if (nota >= 75)
            {
                return "Bueno";
            }
            else
            {
                return "Malo :(";
            }
        }

        




    }
}