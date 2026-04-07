using Clase_10.Models;

namespace Clase_10.Services
{
    public interface IBibliotecaService
    {
        List<Libro> ObtenerTodosLosLibros();
        Libro? ObtenerLibroPorId(int id);
        Libro AgregarLibro(Libro libro);
        Libro? ActualizarLibro(int id, Libro libro);
        bool EliminarLibro(int id);
        List<Libro> BuscarPorAutor(string autor);
        List<Libro> BuscarPorGenero(string genero);
        List<Libro> ObtenerLibrosDisponibles();
    }

    public class BibliotecaService : IBibliotecaService
    {
        private static List<Libro> libros = new List<Libro>
        {
            new Libro 
            {
                Id = 1,
                Titulo = "Cien años de soledad",
                Autor = "Gabriel García Márquez",
                ISBN = "978-0-060-85328-8",
                AnoPublicacion = 1967,
                Genero = "Realismo Mágico",
                Paginas = 417,
                Precio = 45.99m,
                Disponible = true
            },
            new Libro
            {
                Id = 2,
                Titulo = "Don Quijote",
                Autor = "Miguel de Cervantes",
                ISBN = "978-0-575-07889-2",
                AnoPublicacion = 1605,
                Genero = "Novela",
                Paginas = 992,
                Precio = 39.99m,
                Disponible = true
            },
            new Libro
            {
                Id = 3,
                Titulo = "El Código Da Vinci",
                Autor = "Dan Brown",
                ISBN = "978-0-385-33312-0",
                AnoPublicacion = 2003,
                Genero = "Misterio",
                Paginas = 689,
                Precio = 29.99m,
                Disponible = false
            }
        };

        private int proximoId = 4;

        public List<Libro> ObtenerTodosLosLibros()
        {
            return libros;
        }

        public Libro? ObtenerLibroPorId(int id)
        {
            return libros.FirstOrDefault(l => l.Id == id);
        }

        public Libro AgregarLibro(Libro libro)
        {
            libro.Id = proximoId++;
            libros.Add(libro);
            return libro;
        }

        public Libro? ActualizarLibro(int id, Libro libro)
        {
            var libroExistente = libros.FirstOrDefault(l => l.Id == id);
            if (libroExistente == null)
                return null;

            libroExistente.Titulo = libro.Titulo;
            libroExistente.Autor = libro.Autor;
            libroExistente.ISBN = libro.ISBN;
            libroExistente.AnoPublicacion = libro.AnoPublicacion;
            libroExistente.Genero = libro.Genero;
            libroExistente.Paginas = libro.Paginas;
            libroExistente.Precio = libro.Precio;
            libroExistente.Disponible = libro.Disponible;

            return libroExistente;
        }

        public bool EliminarLibro(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro == null)
                return false;

            libros.Remove(libro);
            return true;
        }

        public List<Libro> BuscarPorAutor(string autor)
        {
            return libros.Where(l => l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Libro> BuscarPorGenero(string genero)
        {
            return libros.Where(l => l.Genero.Contains(genero, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Libro> ObtenerLibrosDisponibles()
        {
            return libros.Where(l => l.Disponible).ToList();
        }
    }
}
