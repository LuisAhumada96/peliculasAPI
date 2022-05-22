using peliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace peliculasAPI.Repositorios
{
    public class RepositorioEnMemoria:IRepositorio
    {
        public List<Genero> _generos { get; set; }

        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero(){Id =1, Nombre = "Comedia"},
                new Genero(){Id =2, Nombre = "Acción"}
            };
            _guid = Guid.NewGuid();
        }
        public Guid _guid;
        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }
        public async Task<Genero> ObtenerPorId(int Id)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            return _generos.FirstOrDefault(x => x.Id == Id);
        }
        public Guid ObtenerGUID()
        {
            return _guid;
        }
        public void CrearGenero(Genero genero)
        {
            genero.Id = _generos.Count() + 1;
            _generos.Add(genero);
        }
    }
}
