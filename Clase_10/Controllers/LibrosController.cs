using Microsoft.AspNetCore.Mvc;
using Clase_10.Models;
using Clase_10.Services;

namespace Clase_10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly IBibliotecaService _bibliotecaService;

        public LibrosController(IBibliotecaService bibliotecaService)
        {
            _bibliotecaService = bibliotecaService;
        }

        /// <summary>
        /// Obtiene todos los libros de la biblioteca
        /// </summary>
        /// <returns>Lista de todos los libros</returns>
        [HttpGet]
        public ActionResult<List<Libro>> ObtenerTodos()
        {
            var libros = _bibliotecaService.ObtenerTodosLosLibros();
            return Ok(libros);
        }

        /// <summary>
        /// Obtiene un libro por su ID
        /// </summary>
        /// <param name="id">ID del libro</param>
        /// <returns>El libro solicitado</returns>
        [HttpGet("{id}")]
        public ActionResult<Libro> ObtenerPorId(int id)
        {
            var libro = _bibliotecaService.ObtenerLibroPorId(id);
            if (libro == null)
                return NotFound(new { mensaje = $"Libro con ID {id} no encontrado" });

            return Ok(libro);
        }

        /// <summary>
        /// Obtiene todos los libros disponibles
        /// </summary>
        /// <returns>Lista de libros disponibles</returns>
        [HttpGet("disponibles")]
        public ActionResult<List<Libro>> ObtenerDisponibles()
        {
            var libros = _bibliotecaService.ObtenerLibrosDisponibles();
            return Ok(libros);
        }

        /// <summary>
        /// Busca libros por autor
        /// </summary>
        /// <param name="autor">Nombre del autor</param>
        /// <returns>Lista de libros del autor</returns>
        [HttpGet("buscar/autor/{autor}")]
        public ActionResult<List<Libro>> BuscarPorAutor(string autor)
        {
            var libros = _bibliotecaService.BuscarPorAutor(autor);
            if (libros.Count == 0)
                return Ok(new { mensaje = $"No se encontraron libros del autor: {autor}", libros });

            return Ok(libros);
        }

        /// <summary>
        /// Busca libros por género
        /// </summary>
        /// <param name="genero">Género del libro</param>
        /// <returns>Lista de libros del género</returns>
        [HttpGet("buscar/genero/{genero}")]
        public ActionResult<List<Libro>> BuscarPorGenero(string genero)
        {
            var libros = _bibliotecaService.BuscarPorGenero(genero);
            if (libros.Count == 0)
                return Ok(new { mensaje = $"No se encontraron libros del género: {genero}", libros });

            return Ok(libros);
        }

        /// <summary>
        /// Crea un nuevo libro en la biblioteca
        /// </summary>
        /// <param name="libro">Datos del nuevo libro</param>
        /// <returns>El libro creado con su ID</returns>
        [HttpPost]
        public ActionResult<Libro> Crear(Libro libro)
        {
            if (string.IsNullOrWhiteSpace(libro.Titulo) || string.IsNullOrWhiteSpace(libro.Autor))
                return BadRequest(new { mensaje = "El título y autor son obligatorios" });

            var libroCreado = _bibliotecaService.AgregarLibro(libro);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = libroCreado.Id }, libroCreado);
        }

        /// <summary>
        /// Actualiza un libro existente
        /// </summary>
        /// <param name="id">ID del libro a actualizar</param>
        /// <param name="libro">Nuevos datos del libro</param>
        /// <returns>El libro actualizado</returns>
        [HttpPut("{id}")]
        public ActionResult<Libro> Actualizar(int id, Libro libro)
        {
            if (string.IsNullOrWhiteSpace(libro.Titulo) || string.IsNullOrWhiteSpace(libro.Autor))
                return BadRequest(new { mensaje = "El título y autor son obligatorios" });

            var libroActualizado = _bibliotecaService.ActualizarLibro(id, libro);
            if (libroActualizado == null)
                return NotFound(new { mensaje = $"Libro con ID {id} no encontrado" });

            return Ok(libroActualizado);
        }

        /// <summary>
        /// Elimina un libro de la biblioteca
        /// </summary>
        /// <param name="id">ID del libro a eliminar</param>
        /// <returns>Confirmación de eliminación</returns>
        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var eliminado = _bibliotecaService.EliminarLibro(id);
            if (!eliminado)
                return NotFound(new { mensaje = $"Libro con ID {id} no encontrado" });

            return Ok(new { mensaje = $"Libro con ID {id} eliminado exitosamente" });
        }
    }
}
