using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using peliculasAPI.Entidades;
using peliculasAPI.Filtros;
using peliculasAPI.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace peliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController: ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly WeatherForecastController weatherForecastController;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(IRepositorio repositorio, 
            WeatherForecastController weatherForecastController,
            ILogger<GenerosController> logger)
            
        {
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
            this.logger = logger;
        }
        [HttpGet] // api/generos
        [HttpGet("listado")] // api/generos/listado
        [HttpGet("/listadogeneros")] // /listadogeneros ignora api/generos
        //[ResponseCache(Duration =60)] //Aplicación de filtro a la acción
        [ServiceFilter(typeof(MiFiltroDeAccion))]
        public ActionResult<List<Genero>> Get()
        {
            logger.LogInformation("Vamos a mostrar los géneros");
            return repositorio.ObtenerTodosLosGeneros();
        }
        [HttpGet("guid")] // api/generos/guid
        public ActionResult<Guid> GetGUID()
        {
            
            return Ok( new { GUID_GenerosController = repositorio.ObtenerGUID(),
                GUID_WeatherForecastController = weatherForecastController.ObtenerGUIDWeatherForecastController() });
        }



        //[HttpGet("ejemplo")]
        //[HttpGet("{Id:int}/{nombre=Roberto}")] //Variables de ruta: api/generos/{Id}
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre) //api/generos/ejemplo
        {
            logger.LogDebug($"Obteniendo un género por el id {Id}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            
            var genero =  await repositorio.ObtenerPorId(Id);
            if (genero == null)
            {
                throw new ApplicationException($"El género de ID {Id} no fue encontrado");
                logger.LogWarning($"No pudimos encontrar el género de id {Id}");
                return NotFound();
            }

            return genero;
        }


        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
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
