namespace Clase_10.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int AnoPublicacion { get; set; }
        public string Genero { get; set; } = string.Empty;
        public int Paginas { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; } = true;
    }
}
