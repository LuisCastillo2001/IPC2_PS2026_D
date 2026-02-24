using System;

namespace EjListasAnidadas;

public class ListaDobleCircular
{
    public NodoDobleCircular Raiz { get; private set; }
    public NodoDobleCircular Ultimo { get; private set; }

    public void Append(NodoDobleCircular nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
            Ultimo = nuevoNodo;
            nuevoNodo.Siguiente = Raiz;
            nuevoNodo.Anterior = Ultimo;
        }
        else
        {
            Ultimo.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = Ultimo;
            Ultimo = nuevoNodo;
            Ultimo.Siguiente = Raiz;
            Raiz.Anterior = Ultimo;
        }
    }

    public void Print()
    {
        if (Raiz == null)
        {
            Console.WriteLine("  [Sin empleados]");
            return;
        }

        NodoDobleCircular actual = Raiz;
        do
        {
            Console.WriteLine($"    Empleado: {actual.Empleado.Nombre}, Puesto: {actual.Empleado.Puesto}, Salario: {actual.Empleado.Salario}");
            actual = actual.Siguiente;
        } while (actual != Raiz);
    }

    public void PrintInverso()
    {
        if (Ultimo == null)
        {
            Console.WriteLine("  [Sin empleados]");
            return;
        }

        NodoDobleCircular actual = Ultimo;
        do
        {
            Console.WriteLine($"    Empleado: {actual.Empleado.Nombre}, Puesto: {actual.Empleado.Puesto}, Salario: {actual.Empleado.Salario}");
            actual = actual.Anterior;
        } while (actual != Ultimo);
    }

    public void Pop()
    {
        if (Raiz == null)
        {
            Console.WriteLine("No hay empleados para eliminar.");
            return;
        }

        if (Raiz == Ultimo)
        {
            // Solo un nodo
            Raiz = null;
            Ultimo = null;
            return;
        }

        // Eliminar el último nodo
        NodoDobleCircular penultimo = Ultimo.Anterior;

        penultimo.Siguiente = Raiz;
        Raiz.Anterior = penultimo;
        Ultimo = penultimo;
    }

    public bool EliminarPorNombre(string nombre)
    {
        if (Raiz == null)
        {
            return false;
        }

        NodoDobleCircular actual = Raiz;
        do
        {
            if (actual.Empleado.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                if (actual == Raiz && actual == Ultimo)
                {
                    // Único nodo en la lista
                    Raiz = null;
                    Ultimo = null;
                }
                else if (actual == Raiz)
                {
                    // Eliminar la raíz
                    Raiz = Raiz.Siguiente;
                    Ultimo.Siguiente = Raiz;
                    Raiz.Anterior = Ultimo;
                }
                else if (actual == Ultimo)
                {
                    // Eliminar el último
                    Ultimo = Ultimo.Anterior;
                    Ultimo.Siguiente = Raiz;
                    Raiz.Anterior = Ultimo;
                }
                else
                {
                    // Nodo intermedio
                    actual.Anterior.Siguiente = actual.Siguiente;
                    actual.Siguiente.Anterior = actual.Anterior;
                }

                return true;
            }

            actual = actual.Siguiente;
        } while (actual != Raiz);

        return false;
    }

    private static string Escapar(string texto)
    {
        return texto.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }

    public string GenerarGraphvizEmpleados(string nombreDepartamento)
    {
        if (Raiz == null)
        {
            return "digraph Empleados_" + nombreDepartamento.Replace(" ", "_") + " { }";
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string depNombre = nombreDepartamento.Replace(" ", "_");
        sb.AppendLine("digraph Empleados_" + depNombre + " {");
        sb.AppendLine("  label=\"Lista Doblemente Circular - Empleados de " + Escapar(nombreDepartamento) + "\";");
        sb.AppendLine("  labelloc=\"t\";");
        sb.AppendLine("  fontsize=16;");
        sb.AppendLine("  fontname=\"Arial Bold\";");
        sb.AppendLine("  rankdir=LR;");
        sb.AppendLine("  splines=curved;");
        sb.AppendLine("  nodesep=1.5;");
        sb.AppendLine("  bgcolor=\"white\";");
        sb.AppendLine();
        sb.AppendLine("  node [shape=record, style=\"filled,rounded\", fillcolor=\"#4BC8C8\", fontname=\"Arial Bold\", fontsize=12, color=\"#E8A020\", penwidth=3, height=0.8];");
        sb.AppendLine("  edge [penwidth=2, fontname=\"Arial\", fontsize=9];");
        sb.AppendLine();

        // Definir nodos
        NodoDobleCircular empActual = Raiz;
        do
        {
            string empId = "emp_" + depNombre + "_" + empActual.Empleado.Nombre.Replace(" ", "_");
            string empLabel = "{ " + Escapar(empActual.Empleado.Nombre) + " | " + Escapar(empActual.Empleado.Puesto) + " | Q" + empActual.Empleado.Salario + " }";
            sb.AppendLine("  " + empId + " [label=\"" + empLabel + "\"];");
            empActual = empActual.Siguiente;
        } while (empActual != Raiz);

        sb.AppendLine();

        // Flechas de Siguiente (Sig) - flechas normales entre nodos consecutivos
        empActual = Raiz;
        do
        {
            string empId = "emp_" + depNombre + "_" + empActual.Empleado.Nombre.Replace(" ", "_");
            string nextEmpId = "emp_" + depNombre + "_" + empActual.Siguiente.Empleado.Nombre.Replace(" ", "_");

            if (empActual.Siguiente != Raiz)
            {
                sb.AppendLine("  " + empId + " -> " + nextEmpId + " [color=\"#333333\", arrowhead=vee];");
            }

            empActual = empActual.Siguiente;
        } while (empActual != Raiz);

        sb.AppendLine();

        // Flechas de Anterior (Ant) - flechas inversas entre nodos consecutivos
        empActual = Raiz;
        do
        {
            string empId = "emp_" + depNombre + "_" + empActual.Empleado.Nombre.Replace(" ", "_");
            string prevEmpId = "emp_" + depNombre + "_" + empActual.Anterior.Empleado.Nombre.Replace(" ", "_");

            if (empActual != Raiz)
            {
                sb.AppendLine("  " + empId + " -> " + prevEmpId + " [color=\"#333333\", arrowhead=vee, constraint=false, dir = back];");
            }

            empActual = empActual.Siguiente;
        } while (empActual != Raiz);

        sb.AppendLine();

        // Circular: ultimo -> primero (Sig, por abajo)
        string ultimoId = "emp_" + depNombre + "_" + Ultimo.Empleado.Nombre.Replace(" ", "_");
        string primeroId = "emp_" + depNombre + "_" + Raiz.Empleado.Nombre.Replace(" ", "_");
        sb.AppendLine("  " + ultimoId + " -> " + primeroId + " [color=\"#333333\", arrowhead=vee, constraint=false, tailport=s, headport=s, style=bold, dir=back];");

        sb.AppendLine();

        // Circular: primero -> ultimo (Ant, por arriba)
        sb.AppendLine("  " + primeroId + " -> " + ultimoId + " [color=\"#333333\", arrowhead=vee, constraint=false, tailport=n, headport=n, style=bold];");

        sb.AppendLine("}");
        return sb.ToString();
    }
}
