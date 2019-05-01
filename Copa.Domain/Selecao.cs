using System.Collections.Generic;

namespace Copa.Domain
{
    public class Selecao
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Grupo { get; set; }
        public bool Eliminada { get; set; }
    }
}