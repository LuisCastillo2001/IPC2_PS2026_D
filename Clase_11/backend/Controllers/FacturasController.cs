using Clase_11.Models;
using Clase_11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clase_11.Controllers;

[ApiController]
[Route("[controller]")]
public class FacturasController : ControllerBase
{
    private readonly FacturasService facturasService;

    public FacturasController(FacturasService facturasService)
    {
        this.facturasService = facturasService;
    }

    [HttpGet]
    public ActionResult<List<Factura>> ObtenerTodas()
    {
        var facturas = facturasService.ObtenerTodas();
        return Ok(facturas);
    }

    [HttpGet("{id}")]
    public ActionResult<Factura> ObtenerPorId(int id)
    {
        var factura = facturasService.ObtenerPorId(id);
        if (factura == null)
            return NotFound(new { mensaje = "Factura no encontrada" });

        return Ok(factura);
    }

    [HttpPost]
    public ActionResult<Factura> Crear([FromBody] Factura nuevaFactura)
    {
        if (nuevaFactura.ClienteId <= 0)
            return BadRequest(new { error = "El ClienteId es requerido" });

        var factura = facturasService.Crear(nuevaFactura);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = factura.Id }, factura);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] Factura facturaActualizada)
    {
        var actualizado = facturasService.Actualizar(id, facturaActualizada);
        if (!actualizado)
            return NotFound(new { mensaje = "Factura no encontrada" });

        return Ok(new { mensaje = "Factura actualizada correctamente" });
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var eliminado = facturasService.Eliminar(id);
        if (!eliminado)
            return NotFound(new { mensaje = "Factura no encontrada" });

        return Ok(new { mensaje = "Factura eliminada correctamente" });
    }

    [HttpPost("{facturaId}/lineas")]
    public ActionResult<Factura> AgregarLinea(int facturaId, [FromBody] LineaFactura linea)
    {
        if (linea.Cantidad <= 0 || linea.PrecioUnitario < 0)
            return BadRequest(new { error = "Cantidad y PrecioUnitario deben ser válidos" });

        try
        {
            var facturaActualizada = facturasService.AgregarLinea(facturaId, linea);
            return Ok(facturaActualizada);
        }
        catch (Exception ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }
}
