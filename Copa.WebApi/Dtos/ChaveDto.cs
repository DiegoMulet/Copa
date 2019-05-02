using System.ComponentModel.DataAnnotations;

namespace Copa.WebApi.Dtos
{
    public class ChaveDto
    {
        public int Id { get; set; }
        
        [Required]
        public int Selecao1Id { get; set; }
        
        [Required]
        public int Selecao2Id { get; set; }
        
        [Required]
        public string DataConfronto { get; set; }        
        public int? QtdGols1 { get; set; }
        public int? QtdGols2 { get; set; }
    }
}