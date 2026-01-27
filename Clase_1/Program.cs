using System;

class Program
{
    static void Main(string[] args)
    {
        // Variables
        string nombre;
        int nota;
        char opcion;

        Console.Write("Ingrese el nombre del estudiante: ");
        nombre = Console.ReadLine();

        Console.Write("Ingrese la nota (0 - 100): ");
        nota = Convert.ToInt32(Console.ReadLine());

        // Condicional if - else
        if (nota >= 61)
        {
            Console.WriteLine("Estado: Aprobado ");
        }
        else
        {
            Console.WriteLine("Estado: Reprobado ");
        }

        // Función definida por el usuario
        MostrarMensaje(nota);

        // Uso de switch
        Console.WriteLine("\nSeleccione una opción:");
        Console.WriteLine("A - Ver nota en letras");
        Console.WriteLine("B - Salir");
        opcion = Convert.ToChar(Console.ReadLine().ToUpper());

        switch (opcion)
        {
            case 'A':
                Console.WriteLine(ConvertirNota(nota));
                break;

            case 'B':
                Console.WriteLine("Saliendo del programa...");
                break;

            default:
                Console.WriteLine("Opción no válida");
                break;
        }

        // Ciclo for
        Console.WriteLine("\nConteo regresivo:");
        for (int i = 5; i > 0; i--)
        {
            Console.WriteLine(i);
        }

        // Ciclo while
        int contador = 1;
        Console.WriteLine("\nContador hasta 5:");
        while (contador <= 5)
        {
            Console.WriteLine(contador);
            contador++;
        }

        // Ciclo do-while
        int suma = 0;
        int numero;
        Console.WriteLine("\nIngrese números para sumar (0 para terminar):");
        do
        {
            numero = Convert.ToInt32(Console.ReadLine());
            suma += numero;
        } while (numero != 0);

        Console.WriteLine($"La suma total es: {suma}");


        // Leer un arreglo con for each
        string[] materias = { "Matemáticas", "Ciencias", "Historia", "Lenguaje" };
        Console.WriteLine("\nMaterias inscritas:");
        foreach (string materia in materias)
        {
            Console.WriteLine(materia);
        }

    // Función void
    static void MostrarMensaje(int nota)
    {
        Console.WriteLine($"La nota ingresada fue: {nota}");
    }

    // Función que retorna string
    static string ConvertirNota(int nota)
    {
        if (nota >= 90)
            return "Excelente";
        else if (nota >= 75)
            return "Bueno";
        else if (nota >= 61)
            return "Regular";
        else
            return "Deficiente";
    }
}  
}