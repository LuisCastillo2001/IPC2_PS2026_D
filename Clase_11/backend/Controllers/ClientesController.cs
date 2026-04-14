using Clase_11.Models;
using Clase_11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clase_11.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClientesService clientesService;

    public ClientesController(ClientesService clientesService)
    {
        this.clientesService = clientesService;
    }

    [HttpGet]
    public ActionResult<List<Cliente>> ObtenerTodos()
    {
        var clientes = clientesService.ObtenerTodos();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> ObtenerPorId(int id)
    {
        var cliente = clientesService.ObtenerPorId(id);
        if (cliente == null)
            return NotFound(new { mensaje = "Cliente no encontrado" });

        return Ok(cliente);
    }

    [HttpPost]
    public ActionResult<Cliente> Crear([FromBody] Cliente nuevoCliente)
    {
        if (string.IsNullOrWhiteSpace(nuevoCliente.Nombre))
            return BadRequest(new { error = "El nombre es requerido" });

        var cliente = clientesService.Crear(nuevoCliente);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] Cliente clienteActualizado)
    {
        if (string.IsNullOrWhiteSpace(clienteActualizado.Nombre))
            return BadRequest(new { error = "El nombre es requerido" });

        var actualizado = clientesService.Actualizar(id, clienteActualizado);
        if (!actualizado)
            return NotFound(new { mensaje = "Cliente no encontrado" });

        return Ok(new { mensaje = "Cliente actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var eliminado = clientesService.Eliminar(id);
        if (!eliminado)
            return NotFound(new { mensaje = "Cliente no encontrado" });

        return Ok(new { mensaje = "Cliente eliminado correctamente" });
    }

    [HttpPost("importar")]
    public ActionResult<List<Cliente>> Importar([FromBody] ImportarClientesRequest request)
    {
        if (request.Lineas == null || request.Lineas.Count == 0)
            return BadRequest(new { error = "No hay líneas para importar" });

        var nuevosClientes = clientesService.ImportarDesdeLineas(request.Lineas);
        return Ok(nuevosClientes);
    }
}

public class ImportarClientesRequest
{
    public List<string> Lineas { get; set; } = new();
}
