using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TabelaAlunos.Business;
using TabelaAlunos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace TabelaAlunos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Alunos_Controller : ControllerBase
    {
        private readonly ILogger<Alunos_Controller> _logger;
        public Alunos_Controller(ILogger<Alunos_Controller> logger)
        {
            _logger = logger;
        }

        //Apresenta na Web os valores de Get (os dados que estao no banco de dados)
        [HttpGet("SelectAlunos")]
        public async Task<ActionResult<List<Alunos>>> Get()
        {
            return new OracleConnections().selectAlunos();
        }

        //Adiciona pela web dados no Banco de Dados
        [HttpPost("AddAlunos")]
        public async Task<ActionResult<Alunos>> Post(Alunos alunos)
        {
            new OracleConnections().addAlunos(alunos);
            return alunos;
        }

        //Remove pela web dados no Banco de Dados
        [HttpPost("DelAlunos")]
        public ActionResult<String> Post(int delAlunos)
        {
            new OracleConnections().delAlunos(delAlunos);
            var resultado = new
            {
                Status = 200,
                Mensagem = "Aluno Deletado"
            };

            return Content(resultado.ToString(), "application/json");


        }

    }
}


