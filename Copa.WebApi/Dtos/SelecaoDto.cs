using System.ComponentModel.DataAnnotations;

namespace Copa.WebApi.Dtos
{
    public class SelecaoDto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength=4)]
        public string Pais { get; set; }

        [Required]
        [StringLength(1,MinimumLength=1)]
        public string Grupo { get; set; }
        public bool Eliminada { get; set; }
    }
}