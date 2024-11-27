using apidc.Context;
using apidc.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apidc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly PruebaContext _context;
        public CategoriaController(PruebaContext context)
        {
            this._context = context;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return this._context.Categorias.Include(x=>x.Productos).ToList();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}", Name ="ObtenerCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = this._context.Categorias.Include(x => x.Productos).FirstOrDefault(x => x.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            this._context.Categorias.Add(categoria);
            this._context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerCategoria", new { id = categoria.Id }, categoria);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (id!=categoria.Id)
            {
                return BadRequest();
            }
            this._context.Entry(categoria).State = EntityState.Modified;
            this._context.SaveChanges();
            return Ok();
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = this._context.Categorias.Include(c=>c.Productos).FirstOrDefault(x=>x.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            if (categoria.Productos==null || categoria.Productos.Any())
            {
                var errorResponse = new
                {
                    error = "No se puede eliminar la categoría.",
                    message = "La categoría tiene productos asociados y no se puede eliminar.",
                    code = 400
                };
                return BadRequest(errorResponse);
            }
            this._context.Entry(categoria).State = EntityState.Deleted;
            this._context.SaveChanges();
            return categoria;
        }
    }
}
