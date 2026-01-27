
# Introducción a C#
## Crear un proyecto de consola en C#

```bash
dotnet new console -n MiProyectoConsola
cd MiProyectoConsola
dotnet run
```


## Estructura básica de C#

```csharp
using System;
```
Esto importa las librerías de system necesarias para entrada y salida estandar del programa.

```csharp
namespace MiProyectoConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Hola, Mundo!");
        }
    }
}
```
Este es el punto de entrada del programa. La función `Main` es donde comienza la ejecución. `Console.WriteLine` imprime texto en la consola.

## Variables y Tipos de Datos

```csharp   
type VariableName = value;
```

Existen distintos tipos de datos en C#:
- `int`: Números enteros.
- `float` y `double`: Números de punto flotante.
- `char`: Un solo carácter.
- `string`: Una cadena de caracteres.
- `bool`: Valores booleanos (`true` o `false`).
- `var`: Tipo implícito, el compilador infiere el tipo basado en el valor asignado.