using System;

namespace Copa.Domain
{
    public class Chave
    {
        public int Id { get; set; }
        public Selecao Selecao1 { get; set; }
        public Selecao Selecao2 { get; set; }
        public DateTime DataConfronto { get; set; }
        public int? QtqGols1 { get; set; }
        public int? QtdGols2 { get; set; }
    }
}