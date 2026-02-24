using EjListasAnidadas;
using System.IO;

Console.WriteLine("=== SISTEMA DE GESTIÓN DE EMPRESA ===");
Console.WriteLine("Lista Circular Simple de Departamentos");
Console.WriteLine("Cada departamento contiene una Lista Doblemente Circular de Empleados");
Console.WriteLine();

ListaCircularSimple empresa = new ListaCircularSimple();

bool salir = false;
while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("--- MENÚ PRINCIPAL ---");
    Console.WriteLine("1. Crear departamento");
    Console.WriteLine("2. Listar departamentos y empleados");
    Console.WriteLine("3. Agregar empleado a un departamento");
    Console.WriteLine("4. Eliminar empleado por nombre de un departamento");
    Console.WriteLine("5. Eliminar departamento por nombre");
    Console.WriteLine("6. Mostrar empleados de un departamento");
    Console.WriteLine("7. Mostrar empleados de un departamento en orden inverso");
    Console.WriteLine("8. Eliminar último empleado de un departamento");
    Console.WriteLine("9. Generar Graphviz de departamentos");
    Console.WriteLine("10. Generar Graphviz de empleados de un departamento");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine();

    Console.WriteLine();

    if (opcion == "1")
    {
        CrearDepartamento(empresa);
    }
    else if (opcion == "2")
    {
        empresa.Print();
    }
    else if (opcion == "3")
    {
        AgregarEmpleadoADepartamento(empresa);
    }
    else if (opcion == "4")
    {
        EliminarEmpleadoPorNombre(empresa);
    }
    else if (opcion == "5")
    {
        EliminarDepartamentoPorNombre(empresa);
    }
    else if (opcion == "6")
    {
        MostrarEmpleadosDepartamento(empresa);
    }
    else if (opcion == "7")
    {
        MostrarEmpleadosDepartamentoInverso(empresa);
    }
    else if (opcion == "8")
    {
        EliminarUltimoEmpleadoDepartamento(empresa);
    }
    else if (opcion == "9")
    {
        GenerarGraficoDepartamentos(empresa);
    }
    else if (opcion == "10")
    {
        GenerarGraficoEmpleadosDepartamento(empresa);
    }
    else if (opcion == "0")
    {
        salir = true;
    }
    else
    {
        Console.WriteLine("Opción no válida.");
    }
}

Console.WriteLine("Saliendo del sistema...");

void CrearDepartamento(ListaCircularSimple empresaLocal)
{
    Console.Write("Nombre del departamento: ");
    string nombre = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nombre))
    {
        Console.WriteLine("Nombre inválido.");
        return;
    }

    Console.Write("Ubicación del departamento: ");
    string ubicacion = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(ubicacion))
    {
        Console.WriteLine("Ubicación inválida.");
        return;
    }

    Departamento existente = BuscarDepartamentoPorNombre(empresaLocal, nombre);
    if (existente != null)
    {
        Console.WriteLine("Ya existe un departamento con ese nombre.");
        return;
    }

    Departamento departamento = new Departamento(nombre, ubicacion);
    empresaLocal.Append(new NodoCircularSimple(departamento));
    Console.WriteLine("Departamento creado correctamente.");
}

void AgregarEmpleadoADepartamento(ListaCircularSimple empresaLocal)
{
    Console.Write("Nombre del departamento: ");
    string nombreDepto = Console.ReadLine();

    Departamento departamento = BuscarDepartamentoPorNombre(empresaLocal, nombreDepto);
    if (departamento == null)
    {
        Console.WriteLine("Departamento no encontrado.");
        return;
    }

    Console.Write("Nombre del empleado: ");
    string nombre = Console.ReadLine();
    Console.Write("Puesto: ");
    string puesto = Console.ReadLine();
    Console.Write("Salario (entero): ");
    string salarioTexto = Console.ReadLine();

    int salario;
    if (!int.TryParse(salarioTexto, out salario))
    {
        Console.WriteLine("Salario inválido.");
        return;
    }

    Empleado empleado = new Empleado(nombre, puesto, salario);
    departamento.Empleados.Append(new NodoDobleCircular(empleado));
    Console.WriteLine("Empleado agregado correctamente.");
}

void EliminarEmpleadoPorNombre(ListaCircularSimple empresaLocal)
{
    Console.Write("Nombre del departamento: ");
    string nombreDepto = Console.ReadLine();

    Departamento departamento = BuscarDepartamentoPorNombre(empresaLocal, nombreDepto);
    if (departamento == null)
    {
        Console.WriteLine("Departamento no encontrado.");
        return;
    }

    Console.Write("Nombre del empleado a eliminar: ");
    string nombreEmpleado = Console.ReadLine();

    bool eliminado = departamento.Empleados.EliminarPorNombre(nombreEmpleado);
    if (eliminado)
    {
        Console.WriteLine("Empleado eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("Empleado no encontrado.");
    }
}

void EliminarDepartamentoPorNombre(ListaCircularSimple empresaLocal)
{
    Console.Write("Nombre del departamento a eliminar: ");
    string nombreDepto = Console.ReadLine();

    bool eliminado = empresaLocal.EliminarPorNombre(nombreDepto);
    if (eliminado)
    {
        Console.WriteLine("Departamento eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("Departamento no encontrado.");
    }
}

void MostrarEmpleadosDepartamento(ListaCircularSimple empresaLocal)
{
    Console.Write("Nombre del departamento: ");
    string nombreDepto = Console.ReadLine();

    Departamento departamento = BuscarDepartamentoPorNombre(empresaLocal, nombreDepto);
    if (departamento == null)
    {
        Console.WriteLine("Departamento no encontrado.");
        return;
    }

    departamento.Empleados.Print();
}

void MostrarEmpleadosDepartamentoInverso(ListaCircularSimple empresaLocal)
{
    Console.Write("Nombre del departamento: ");
    string nombreDepto = Console.ReadLine();

    Departamento departamento = BuscarDepartamentoPorNombre(empresaLocal, nombreDepto);
    if (departamento == null)
    {
        Console.WriteLine("Departamento no encontrado.");
        return;
    }

    departamento.Empleados.PrintInverso();
}

void EliminarUltimoEmpleadoDepartamento(ListaCircularSimple empresaLocal)
{
    Console.Write("Nombre del departamento: ");
    string nombreDepto = Console.ReadLine();

    Departamento departamento = BuscarDepartamentoPorNombre(empresaLocal, nombreDepto);
    if (departamento == null)
    {
        Console.WriteLine("Departamento no encontrado.");
        return;
    }

    departamento.Empleados.Pop();
}

void GenerarGraficoDepartamentos(ListaCircularSimple empresaLocal)
{
    string dot = empresaLocal.GenerarGraphvizDepartamentos();
    string rutaDot = Path.Combine(Directory.GetCurrentDirectory(), "empresa_departamentos.dot");
    File.WriteAllText(rutaDot, dot);
    Console.WriteLine("Archivo DOT de departamentos generado: " + rutaDot);

    try
    {
        System.Diagnostics.Process proceso = new System.Diagnostics.Process();
        proceso.StartInfo.FileName = "dot";
        proceso.StartInfo.Arguments = "-Tpng \"" + rutaDot + "\" -o \"" + rutaDot.Replace(".dot", ".png") + "\"";
        proceso.StartInfo.UseShellExecute = false;
        proceso.StartInfo.CreateNoWindow = true;
        proceso.Start();
        proceso.WaitForExit();

        if (proceso.ExitCode == 0)
        {
            Console.WriteLine("Imagen PNG de departamentos generada: " + rutaDot.Replace(".dot", ".png"));
        }
        else
        {
            Console.WriteLine("Error al generar PNG de departamentos. Asegúrate de tener Graphviz instalado.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("No se pudo ejecutar Graphviz: " + ex.Message);
    }
}

void GenerarGraficoEmpleadosDepartamento(ListaCircularSimple empresaLocal)
{
    Console.Write("Nombre del departamento: ");
    string nombreDepto = Console.ReadLine();

    Departamento departamento = BuscarDepartamentoPorNombre(empresaLocal, nombreDepto);
    if (departamento == null)
    {
        Console.WriteLine("Departamento no encontrado.");
        return;
    }

    string dot = departamento.Empleados.GenerarGraphvizEmpleados(departamento.Nombre);
    string nombreSeguro = departamento.Nombre.Replace(" ", "_");
    string rutaDot = Path.Combine(Directory.GetCurrentDirectory(), "empleados_" + nombreSeguro + ".dot");
    File.WriteAllText(rutaDot, dot);
    Console.WriteLine("Archivo DOT de empleados generado: " + rutaDot);

    try
    {
        System.Diagnostics.Process proceso = new System.Diagnostics.Process();
        proceso.StartInfo.FileName = "dot";
        proceso.StartInfo.Arguments = "-Tpng \"" + rutaDot + "\" -o \"" + rutaDot.Replace(".dot", ".png") + "\"";
        proceso.StartInfo.UseShellExecute = false;
        proceso.StartInfo.CreateNoWindow = true;
        proceso.Start();
        proceso.WaitForExit();

        if (proceso.ExitCode == 0)
        {
            Console.WriteLine("Imagen PNG de empleados generada: " + rutaDot.Replace(".dot", ".png"));
        }
        else
        {
            Console.WriteLine("Error al generar PNG de empleados. Asegúrate de tener Graphviz instalado.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("No se pudo ejecutar Graphviz: " + ex.Message);
    }
}

Departamento BuscarDepartamentoPorNombre(ListaCircularSimple empresaLocal, string nombre)
{
    if (empresaLocal.Raiz == null)
    {
        return null;
    }

    NodoCircularSimple actual = empresaLocal.Raiz;
    do
    {
        if (string.Equals(actual.Departamento.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
        {
            return actual.Departamento;
        }

        actual = actual.Siguiente;
    } while (actual != empresaLocal.Raiz);

    return null;
}
