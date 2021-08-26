using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TabelaAlunos.Database;
using TabelaAlunos.Model;

namespace TabelaAlunos.Controllers
{
    public class AuthenticationController : Controller
    {

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            // Recupera o usuário
            var user = User_Repository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenServices.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }


        [HttpGet]
        [Route("aluno")]
        [Authorize(Roles ="aluno")]
        public string Studants() => String.Format("aluno - {0}", User.Identity.Name);

        [HttpGet]
        [Route("professor")]
        [Authorize(Roles = "professor,diretor")]
        public string Teacher() => "professor";

        [HttpGet]
        [Route("diretor")]
        [Authorize(Roles = "diretor")]
        public string Director() => "diretor";


    }
}
