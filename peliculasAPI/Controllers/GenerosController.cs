using Microsoft.AspNetCore.Mvc;
using peliculasAPI.Entidades;
using peliculasAPI.Repositorios;
using System.Collections.Generic;

namespace peliculasAPI.Controllers
{
    [Route("api/generos")]
    public class GenerosController
    {
        private readonly IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        [HttpGet]
        public List<Genero> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }
        [HttpPost]
        public void Post()
        {
             
        }
        [HttpPut]
        public void Put()
        {

        }
        [HttpDelete]
        public void Delete()
        {

        }
    }
}
