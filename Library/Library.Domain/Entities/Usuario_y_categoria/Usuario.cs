﻿using Library.Domain.Core;

namespace Library.Domain.Entities.Usuario_y_categoria
{
    internal class Usuario : BaseEntity
    {
        public int idUsuario { get; set; }
        public string? nombreApellidos { get; set; }
        public string? correo { get; set; }
        public string? clave { get; set; }
        public bool esActivo { get; set; }
    }
}
