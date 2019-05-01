using System.ComponentModel.DataAnnotations;

namespace Copa.WebApi.Dtos
{
    public class ChaveDto
    {
        public int Id { get; set; }
        
        [Required]
        public SelecaoDto Selecao1 { get; set; }
        
        [Required]
        public SelecaoDto Selecao2 { get; set; }
        
        [Required]
        public string DataConfronto { get; set; }
        
        [MaxLength(20)]
        public int? QtqGols1 { get; set; }
        
        [MaxLength(20)]
        public int? QtdGols2 { get; set; }
    }
}