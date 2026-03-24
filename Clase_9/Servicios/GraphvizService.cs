using System.Text;
using Clase_8.Estructuras;

namespace Clase_8.Servicios;

public class GraphvizService
{
    public string GenerarDiagrama(ListaDrones listaDrones)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("digraph Drones {");
        sb.AppendLine("    rankdir=LR;");
        sb.AppendLine("    node [shape=box, style=rounded];");
        sb.AppendLine("    graph [bgcolor=lightblue];");

        if (listaDrones.Raiz == null)
        {
            sb.AppendLine("    lista [label=\"Lista Vacía\"];");
        }
        else
        {
            var nodo = listaDrones.Raiz;
            int contador = 0;

            while (nodo != null)
            {
                string nombreNodo = $"dron{contador}";
                string etiqueta = $"{nodo.Dron.Nombre}\\nAltura: {nodo.Dron.AlturaActual}m\\nLuz: {(nodo.Dron.LuzActiva ? "ON" : "OFF")}";
                sb.AppendLine($"    {nombreNodo} [label=\"{etiqueta}\"];");

                if (nodo.Siguiente != null)
                {
                    string siguienteNodo = $"dron{contador + 1}";
                    sb.AppendLine($"    {nombreNodo} -> {siguienteNodo};");
                }

                nodo = nodo.Siguiente;
                contador++;
            }
        }

        sb.AppendLine("}");
        return sb.ToString();
    }

    public void ExportarImage(string dotContent, string rutaArchivo)
    {
        try
        {
            string rutaTmp = Path.Combine(Path.GetTempPath(), "temp.dot");
            File.WriteAllText(rutaTmp, dotContent);

            // Intentar usar graphviz si está instalado
            string formatoSalida = Path.GetExtension(rutaArchivo).Remove(0, 1);
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "dot",
                Arguments = $"-T{formatoSalida} \"{rutaTmp}\" -o \"{rutaArchivo}\"",
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var proceso = System.Diagnostics.Process.Start(psi))
            {
                proceso.WaitForExit();
                if (proceso.ExitCode != 0)
                {
                    throw new Exception("Error al ejecutar Graphviz");
                }
            }

            File.Delete(rutaTmp);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al exportar imagen: {ex.Message}", ex);
        }
    }
}
