using Clase_12.Dtos;
using Clase_12.Models;
using Clase_12.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clase_12.Controllers;

[ApiController]
[Route("api/productos")]
[Authorize]
public sealed class ProductosController(IProductoService productoService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Producto>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<Producto>> GetAll()
    {
        return Ok(productoService.GetAll());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Producto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Producto> GetById([FromRoute] int id)
    {
        var item = productoService.GetById(id);
        return item is null
            ? NotFound(new { message = "Producto no encontrado." })
            : Ok(item);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Producto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Producto> Create([FromBody] CreateProductoRequest request)
    {
        var created = productoService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateProductoRequest request)
    {
        var updated = productoService.Update(id, request);
        return updated
            ? NoContent()
            : NotFound(new { message = "Producto no encontrado." });
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        var deleted = productoService.Delete(id);
        return deleted
            ? NoContent()
            : NotFound(new { message = "Producto no encontrado." });
    }
}
