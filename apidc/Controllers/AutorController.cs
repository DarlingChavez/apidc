using apidc.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apidc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private readonly Persistence.AutorRepository _repo;
        public AutorController()
        {
            _repo = new Persistence.AutorRepository(Helpers.Configuration.Instance.GetConnectionString());
        }

        // GET: api/<AutorController>
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return this._repo.ObtenerAutor();
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AutorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
