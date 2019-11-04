using System;
using System.Collections.Generic;

namespace Senai.Roman.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Aulas = new HashSet<Aulas>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Aulas> Aulas { get; set; }
    }
}
