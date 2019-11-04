using System;
using System.Collections.Generic;

namespace Senai.Roman.WebApi.Domains
{
    public partial class Aulas
    {
        public int IdAula { get; set; }
        public string Nome { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTema { get; set; }

        public Temas IdTemaNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
