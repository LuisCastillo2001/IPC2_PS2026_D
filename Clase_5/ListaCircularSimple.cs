using System;
using System.Text;

namespace EjListasAnidadas;

public class ListaCircularSimple
{
    public NodoCircularSimple Raiz { get; private set; }

    public void Append(NodoCircularSimple nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
            Raiz.Siguiente = Raiz;
        }
        else
        {
            NodoCircularSimple actual = Raiz;
            while (actual.Siguiente != Raiz)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
            nuevoNodo.Siguiente = Raiz;
        }
    }

    public void Pop()
    {
        if (Raiz == null)
        {
            Console.WriteLine("La lista de departamentos está vacía.");
            return;
        }

        if (Raiz.Siguiente == Raiz)
        {
            // Solo un departamento
            Raiz = null;
            return;
        }

        NodoCircularSimple actual = Raiz;
        while (actual.Siguiente.Siguiente != Raiz)
        {
            actual = actual.Siguiente;
        }
        // actual es el penúltimo, su siguiente es el último
        actual.Siguiente = Raiz;
    }

    public bool EliminarPorNombre(string nombre)
    {
        if (Raiz == null)
        {
            return false;
        }

        // Caso de un solo nodo
        if (Raiz.Siguiente == Raiz)
        {
            if (string.Equals(Raiz.Departamento.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
            {
                Raiz = null;
                return true;
            }
            return false;
        }

        NodoCircularSimple actual = Raiz;
        NodoCircularSimple anterior = null;

        do
        {
            if (string.Equals(actual.Departamento.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
            {
                if (anterior == null)
                {
                    // Eliminar la raíz en una lista con más de un nodo
                    NodoCircularSimple ultimo = Raiz;
                    while (ultimo.Siguiente != Raiz)
                    {
                        ultimo = ultimo.Siguiente;
                    }
                    Raiz = actual.Siguiente;
                    ultimo.Siguiente = Raiz;
                }
                else
                {
                    // Eliminar nodo intermedio o último
                    anterior.Siguiente = actual.Siguiente;
                }
                return true;
            }

            anterior = actual;
            actual = actual.Siguiente;
        } while (actual != Raiz);

        return false;
    }

    public void Print()
    {
        if (Raiz == null)
        {
            Console.WriteLine("[Lista de departamentos vacía]");
            return;
        }

        NodoCircularSimple actual = Raiz;
        do
        {
            Console.WriteLine($"Departamento: {actual.Departamento.Nombre} ({actual.Departamento.Ubicacion})");
            actual.Departamento.Empleados.Print();
            actual = actual.Siguiente;
            Console.WriteLine();
        } while (actual != Raiz);
    }

    private static string Escapar(string texto)
    {
        return texto.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }

    public string GenerarGraphvizDepartamentos()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("digraph Departamentos {");
        sb.AppendLine("  label=\"Lista Circular Simple de Departamentos\";");
        sb.AppendLine("  labelloc=\"t\";");
        sb.AppendLine("  fontsize=18;");
        sb.AppendLine("  fontname=\"Arial Bold\";");
        sb.AppendLine("  rankdir=LR;");
        sb.AppendLine("  nodesep=1.0;");
        sb.AppendLine("  node [shape=record, style=filled, fillcolor=\"#87CEEB\", fontname=\"Arial\", fontsize=12];");
        sb.AppendLine("  edge [penwidth=2];");
        sb.AppendLine();

        if (Raiz != null)
        {
            NodoCircularSimple actualDept = Raiz;
            do
            {
                string depId = "dep_" + actualDept.Departamento.Nombre.Replace(" ", "_");
                string depLabel = "{ " + Escapar(actualDept.Departamento.Nombre) + " | " + Escapar(actualDept.Departamento.Ubicacion) + " }";
                sb.AppendLine("  " + depId + " [label=\"" + depLabel + "\"];");

                actualDept = actualDept.Siguiente;
            } while (actualDept != Raiz);

            sb.AppendLine();

            actualDept = Raiz;
            NodoCircularSimple ultimoDept = Raiz;
            while (ultimoDept.Siguiente != Raiz)
            {
                ultimoDept = ultimoDept.Siguiente;
            }

            do
            {
                string depId = "dep_" + actualDept.Departamento.Nombre.Replace(" ", "_");
                string nextDepId = "dep_" + actualDept.Siguiente.Departamento.Nombre.Replace(" ", "_");

                if (actualDept == ultimoDept)
                {
                    sb.AppendLine("  " + depId + " -> " + nextDepId + " [color=\"#FF0000\", penwidth=3, style=bold, label=\"Regresa al inicio\", fontsize=10, fontcolor=\"#FF0000\"];");
                }
                else
                {
                    sb.AppendLine("  " + depId + " -> " + nextDepId + " [color=\"#4169E1\"];");
                }

                actualDept = actualDept.Siguiente;
            } while (actualDept != Raiz);
        }

        sb.AppendLine("}");
        return sb.ToString();
    }

    // La generación de gráficos de empleados por departamento se hace ahora
    // directamente en ListaDobleCircular (una imagen por departamento).
}
