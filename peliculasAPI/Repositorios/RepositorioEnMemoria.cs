using peliculasAPI.Entidades;
using System.Collections.Generic;

namespace peliculasAPI.Repositorios
{
    public class RepositorioEnMemoria:IRepositorio
    {
        public List<Genero> _generos { get; set; }

        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero(){Id =1, Nombre = "Comedia"}
            };
        }
        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }
    }
}
