
using Library.Api.Models;
using Library.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<CategoriaController>
        [HttpGet("GetCategorias")]
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

        // GET api/<CategoriaController>/5
        [HttpGet("GetCategoriaById")]
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

        // POST api/<CategoriaController>
        [HttpPost("SaveCategory")]
        public void Post([FromBody] CategoriaGetModel categoriaAddModel)
        {
            this.categoriaRepository.Save(new Domain.Entities.Usuario_y_categoria.Categoria()
            {
                Descripcion = categoriaAddModel.descripcion,
                Estado = categoriaAddModel.estado,
                FechaCreacion = categoriaAddModel.fechaCreacion
            });
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
