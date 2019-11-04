using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Repositories
{
    public class UsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        public Usuarios BuscarUser (LoginViewModel login)
        {
            Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            if (usuario == null)
            {
                return null;
            }
            return usuario;
        }
    }
}
