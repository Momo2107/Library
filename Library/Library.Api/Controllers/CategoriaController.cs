
using Library.Api.Dtos.Categoria;
using Library.Api.Models;
using Library.Domain.Entities.Usuario_y_categoria;
using Library.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        [HttpGet("GetCategory")]
        public IActionResult Get()
        {
            var categoria = this.categoriaRepository.GetEntities().Select(categoria => new CategoriaGetModel()
            {
                Idcategoria = categoria.IdCategoria,
                descripcion = categoria.Descripcion,
                estado = categoria.Estado,
                fechaCreacion = categoria.FechaCreacion
            });
            
            return Ok(categoria);
        }

        [HttpGet("GetCategoryById")]
        public IActionResult Get(int id)
        {
            var categoria = this.categoriaRepository.GetEntity(id);
            CategoriaGetModel categoriaGetModel = new CategoriaGetModel()
            {
                descripcion = categoria.Descripcion, 
                estado = categoria.Estado, 
                fechaCreacion = categoria.FechaCreacion
            };
            return Ok(categoria);
        }

        [HttpPost("SaveCategory")]
        public IActionResult Post([FromBody] CategoriaAddDto categoriaAddDto)
        {
            this.categoriaRepository.Save(new Domain.Entities.Usuario_y_categoria.Categoria()
            {
                Descripcion = categoriaAddDto.descripcion,
                Estado = categoriaAddDto.estado,
                FechaCreacion = categoriaAddDto.ChangeDate
            });
            return Ok("Categoria guardada correctamente.");
        }

        [HttpPut("UpdateCategory")]
        public IActionResult Put([FromBody] CategoriaUpdateDto categoriaUpdate)
        {
            this.categoriaRepository.Update(new Categoria()
            {
                IdCategoria = categoriaUpdate.Idcategoria,
                Descripcion = categoriaUpdate.descripcion,
                Estado = categoriaUpdate.estado,
                FechaCreacion = categoriaUpdate.ChangeDate

            });
            return Ok("Categoria actualizada correctamente.");
        }

        [HttpDelete("RemoveCategory")]
        public IActionResult Delete([FromBody] CategoriaRemoveDto categoriaRemove)
        {
            this.categoriaRepository.Remove(new Categoria()
            {
                IdCategoria = categoriaRemove.Idcategoria,
                FechaCreacion = categoriaRemove.ChangeDate 
            });
            return Ok("Categoria eliminada correctamente.");
        }
        
    }
}
