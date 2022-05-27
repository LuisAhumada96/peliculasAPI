﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using peliculasAPI.Utilidades;
using System;
using System.Collections.Generic;

namespace peliculasAPI.DTOs
{
    public class PeliculaCreacionDTO
    {
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Trailer { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public IFormFile Poster { get; set; }
        [ModelBinder(BinderType =typeof(TypeBinder<List<int>>))]
        public List<int> GenerosIds { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> CinesIds { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorPeliculaCreacionDTO>>))]
        public List<ActorPeliculaCreacionDTO> Actores { get; set; }
    }
}
