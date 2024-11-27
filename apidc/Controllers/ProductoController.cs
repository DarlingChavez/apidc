using apidc.Context;
using apidc.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apidc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly PruebaContext _context;
        public ProductoController(PruebaContext context)
        {
            this._context = context;
        }
        
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return this._context.Productos.Include(x => x.Categoria).ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}", Name ="ObtenerProductos")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = this._context.Productos.Include(x => x.Categoria).FirstOrDefault(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            this._context.Productos.Add(producto);
            this._context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerProductos", new { id = producto.Id }, producto);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }
            this._context.Entry(producto).State = EntityState.Modified;
            this._context.SaveChanges();
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult<Producto> Delete(int id)
        {
            var producto = this._context.Productos.Include(p=>p.Categoria).FirstOrDefault(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            this._context.Entry(producto).State = EntityState.Deleted;
            this._context.SaveChanges();
            return producto;
        }
    }
}
