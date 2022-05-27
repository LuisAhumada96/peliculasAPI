﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peliculasAPI.DTOs;
using peliculasAPI.Entidades;
using peliculasAPI.Utilidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace peliculasAPI.Controllers
{
    [ApiController]
    [Route("api/cines")]
    public class CinesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CinesController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<CineDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Cines.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var cines = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<CineDTO>>(cines);
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<CineDTO>> Get(int Id) //api/generos/ejemplo
        {
            var cine = await context.Generos.FirstOrDefaultAsync(x => x.Id == Id);
            if (cine == null)
            {
                return NotFound();
            }
            return mapper.Map<CineDTO>(cine);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CineCreacionDTO cineCreacionDTO)
        {
            var cine = mapper.Map<Cine>(cineCreacionDTO);
            context.Add(cine);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CineCreacionDTO cineCreacionDTO)
        {
            var cine = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            if (cine == null)
            {
                return NotFound();
            }
            cine = mapper.Map(cineCreacionDTO, cine);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Cines.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Cine() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
