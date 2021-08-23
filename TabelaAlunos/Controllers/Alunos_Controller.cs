using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TabelaAlunos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TabelaAlunos.Repository;
using TabelaAlunos.Business;

namespace TabelaAlunos.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class Alunos_Controller : ControllerBase
    {
        private readonly ILogger<Alunos_Controller> _logger;
        private IAlu_Business _alu_Business;

        public Alunos_Controller(ILogger<Alunos_Controller> logger, IAlu_Business alu_Business)
        {
            _logger = logger;
            _alu_Business = alu_Business;
        }

        //Apresenta na Web os valores de Get (os dados que estao no banco de dados)
        [HttpGet("SelectAlunos")]
        public async Task<ActionResult<List<Alunos>>> Get()
        {
            return _alu_Business.selectAlunos();
        }

        //Adiciona pela web dados no Banco de Dados
        [HttpPost("AddAlunos")]
        public async Task<ActionResult<Alunos>> Post(Alunos alunos)
        {
            return _alu_Business.addAlunos(alunos);
        }

        //Remove pela web dados no Banco de Dados
        [HttpPost("DelAlunos")]
        public void Post(int delAlunos)
        {
            _alu_Business.delAlunos(delAlunos);

        }

    }
}


