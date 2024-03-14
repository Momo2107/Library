
using Library.Api.Dtos.Usuario;
using Library.Api.Models;
using Library.Domain.Entities.Usuario_y_categoria;
using Library.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository) 
        {
            this.usuarioRepository = usuarioRepository;
        }
        [HttpGet("GetUser")]
        public IActionResult Get()
        {
            var usuario = this.usuarioRepository.GetEntities().Select(usuario => new UsuarioGetModel()
            {
                IdUsuario = usuario.idUsuario,
                NombreApellidos = usuario.nombreApellidos,
                Correo = usuario.correo,
                Clave = usuario.clave,
                EsActivo = usuario.esActivo,
                fechaCreacion = usuario.FechaCreacion
            });
            return Ok(usuario);
        }

        [HttpGet("GetUserById")]
        public IActionResult Get(int id)
        {
            var usuario = this.usuarioRepository.GetEntity(id);
            UsuarioGetModel usuarioGetModel = new UsuarioGetModel()
            {
                NombreApellidos = usuario.nombreApellidos,
                Correo = usuario.correo,
                Clave = usuario.clave,
                EsActivo = usuario.esActivo,
                fechaCreacion = usuario.FechaCreacion
            };
            return Ok(usuario);
        }

        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] UsuarioAddDto usuarioAddDto)
        {
            this.usuarioRepository.Save(new Domain.Entities.Usuario_y_categoria.Usuario()
            {
                nombreApellidos = usuarioAddDto.NombreApellidos,
                correo = usuarioAddDto.Correo,
                clave = usuarioAddDto.Clave,
                esActivo = usuarioAddDto.EsActivo,
                FechaCreacion = usuarioAddDto.ChangeDate
            });
            return Ok("Usuario guardado correctamente.");
        }

        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] UsuarioUpdateDto usuarioUpdateDto)
        {
            var usuario = this.usuarioRepository.GetEntity(usuarioUpdateDto.IdUsuario);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            usuario.nombreApellidos = usuarioUpdateDto.NombreApellidos;
            usuario.correo = usuarioUpdateDto.Correo;
            usuario.clave = usuarioUpdateDto.Clave;
            usuario.esActivo = usuarioUpdateDto.EsActivo;
            usuario.FechaCreacion = usuarioUpdateDto.ChangeDate;

            this.usuarioRepository.Update(usuario);

            return Ok("Usuario actualizado correctamente.");
        }

        [HttpDelete("RemoveUser")]
        public IActionResult Delete([FromBody] UsuarioRemoveDto usuarioRemoveDto)
        {
            this.usuarioRepository.Remove(new Usuario()
            {
                idUsuario = usuarioRemoveDto.IdUsuario,
                FechaCreacion = usuarioRemoveDto.ChangeDate
            });
            return Ok("Categoria eliminada correctamente.");
        }
    }
}
