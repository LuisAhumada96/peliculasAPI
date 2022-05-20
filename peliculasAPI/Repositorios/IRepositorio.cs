using peliculasAPI.Entidades;
using System.Collections.Generic;

namespace peliculasAPI.Repositorios
{
    public interface IRepositorio
    {
        Genero ObtenerPorId(int Id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
