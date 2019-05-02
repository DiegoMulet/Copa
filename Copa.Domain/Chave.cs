using System;

namespace Copa.Domain
{
    public class Chave
    {
        public int Id { get; set; }
        public int Selecao1Id { get; set; }
        public int Selecao2Id { get; set; }
        public DateTime DataConfronto { get; set; }
        public int? QtdGols1 { get; set; }
        public int? QtdGols2 { get; set; }
    }
}