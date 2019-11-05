using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.Repositories;
using Senai.Roman.WebApi.ViewModels;

namespace Senai.Roman.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]
    public class AulasController : ControllerBase
    { 
        AulaRepository AulaRepository = new AulaRepository();

        [Authorize]
        [HttpGet]
        public IActionResult ListarAulas()
        {
            return Ok(AulaRepository.Listar());
        }

        [Authorize]
        [HttpPost]
        public IActionResult CadastrarAula(Aulas aula)
        {
            try
            {
                AulaRepository.Cadastrar(aula);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}