using peliculasAPI.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace peliculasAPI.Repositorios
{
    public interface IRepositorio
    {
        Task<Genero> ObtenerPorId(int Id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
