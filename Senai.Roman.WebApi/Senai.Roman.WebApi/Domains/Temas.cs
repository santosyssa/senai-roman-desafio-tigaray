using System;
using System.Collections.Generic;

namespace Senai.Roman.WebApi.Domains
{
    public partial class Temas
    {
        public Temas()
        {
            Aulas = new HashSet<Aulas>();
        }

        public int IdTema { get; set; }
        public string Nome { get; set; }

        public ICollection<Aulas> Aulas { get; set; }
    }
}
