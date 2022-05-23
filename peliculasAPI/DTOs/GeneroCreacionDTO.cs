using peliculasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace peliculasAPI.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10)]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}
