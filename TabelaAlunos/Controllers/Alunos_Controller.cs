using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TabelaAlunos.Database;
using TabelaAlunos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TabelaAlunos.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
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
        public void Post(int delAlunos)
        {
            new OracleConnections().delAlunos(delAlunos);
            
        }
    }
}
