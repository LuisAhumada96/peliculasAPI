using peliculasAPI.Validaciones;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace peliculasAPI.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:10)]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public List<PeliculasGeneros> PeliculasGeneros { get; set; }
    }
}
