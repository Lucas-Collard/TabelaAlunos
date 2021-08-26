using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TabelaAlunos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using TabelaAlunos.Business;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "professor,diretor,aluno")]
        [ProducesResponseType((200), Type = typeof(List<Alunos>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public async Task<ActionResult<List<Alunos>>> Get()
        {
            return _alu_Business.selectAlunos();
        }

        //Adiciona pela web dados no Banco de Dados
        [HttpPost("AddAlunos")]
        [Authorize(Roles = "professor,diretor")]
        [ProducesResponseType((200), Type = typeof(Alunos))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<Alunos>> Post(Alunos alunos)
        {
            return _alu_Business.addAlunos(alunos);
        }

        //Remove pela web dados no Banco de Dados
        [HttpPost("DelAlunos")]
        [Authorize(Roles = "diretor")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public void Post(int delAlunos)
        {
            _alu_Business.delAlunos(delAlunos);

        }

        [HttpGet("SelectAlunos_Excluidos")]
        [Authorize(Roles = "diretor")]
        [ProducesResponseType((200), Type = typeof(List<Alunos_Excluidos>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<List<Alunos_Excluidos>>> GetResult()
        {
            return _alu_Business.selectAlunosEx();
        }
    }
}


