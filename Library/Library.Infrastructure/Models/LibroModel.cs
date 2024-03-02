﻿
namespace Library.Infrastructure.Models
{
    public class LibroModel
    {
        public int IdLibro { get; set; }
        public int IdCategoria { get; set; }
        public int Ejemplares { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Editorial { get; set; }
        public string? Ubicacion { get; set; }
        public string? Portada { get; set; }
    }
}
