using Clase_11.Models;

namespace Clase_11.Services;

public class ClientesService
{
    private static List<Cliente> clientes = new()
    {
        new Cliente { Id = 1, Nombre = "Juan García", Correo = "juan@gmail.com", Telefono = "7777-1234", Direccion = "Zona 1, Guatemala" },
        new Cliente { Id = 2, Nombre = "María López", Correo = "maria@gmail.com", Telefono = "7777-5678", Direccion = "Zona 10, Guatemala" },
        new Cliente { Id = 3, Nombre = "Pedro Rodríguez", Correo = "pedro@gmail.com", Telefono = "7777-9012", Direccion = "Zona 3, Guatemala" }
    };

    private static int proximoId = 4;

    public List<Cliente> ObtenerTodos()
    {
        return clientes;
    }

    public Cliente? ObtenerPorId(int id)
    {
        return clientes.FirstOrDefault(c => c.Id == id);
    }

    public Cliente Crear(Cliente nuevoCliente)
    {
        nuevoCliente.Id = proximoId++;
        nuevoCliente.FechaRegistro = DateTime.Now;
        clientes.Add(nuevoCliente);
        return nuevoCliente;
    }

    public bool Actualizar(int id, Cliente clienteActualizado)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
            return false;

        cliente.Nombre = clienteActualizado.Nombre;
        cliente.Correo = clienteActualizado.Correo;
        cliente.Telefono = clienteActualizado.Telefono;
        cliente.Direccion = clienteActualizado.Direccion;

        return true;
    }

    public bool Eliminar(int id)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
            return false;

        clientes.Remove(cliente);
        return true;
    }

    public List<Cliente> ImportarDesdeLineas(List<string> lineas)
    {
        var nuevosClientes = new List<Cliente>();

        foreach (var linea in lineas)
        {
            if (string.IsNullOrWhiteSpace(linea))
                continue;

            var partes = linea.Split('|');
            if (partes.Length < 4)
                continue;

            var cliente = new Cliente
            {
                Nombre = partes[0].Trim(),
                Correo = partes[1].Trim(),
                Telefono = partes[2].Trim(),
                Direccion = partes[3].Trim()
            };

            var clienteCreado = Crear(cliente);
            nuevosClientes.Add(clienteCreado);
        }

        return nuevosClientes;
    }
}
