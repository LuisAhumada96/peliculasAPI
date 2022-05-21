using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using peliculasAPI.Entidades;
using peliculasAPI.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace peliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController: ControllerBase
    {
        private readonly IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        [HttpGet] // api/generos
        [HttpGet("listado")] // api/generos/listado
        [HttpGet("/listadogeneros")] // /listadogeneros ignora api/generos
        public ActionResult<List<Genero>> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }

        //[HttpGet("ejemplo")]
        //[HttpGet("{Id:int}/{nombre=Roberto}")] //Variables de ruta: api/generos/{Id}
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre) //api/generos/ejemplo
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            
            var genero =  await repositorio.ObtenerPorId(Id);
            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }


        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            return NoContent();  
        }
        [HttpPut]
        public ActionResult Put()
        {
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}
