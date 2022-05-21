using System.ComponentModel.DataAnnotations;

namespace peliculasAPI.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:10)]
        public string Nombre { get; set; }
    }
}
