using Microsoft.EntityFrameworkCore;
using Senai.Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Repositories
{
    public class AulaRepository
    {
       RomanContext ctx = new RomanContext();

        public List<Aulas> Listar()
        {
            return ctx.Aulas.Include(x => x.IdUsuarioNavigation).Include(x => x.IdTemaNavigation).ToList();
        }

        public void Cadastrar(Aulas aula)
        {
            ctx.Aulas.Add(aula);
            ctx.SaveChanges();
        }
    }
}
