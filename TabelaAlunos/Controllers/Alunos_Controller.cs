using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TabelaAlunos.Database;
using TabelaAlunos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TabelaAlunos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Alunos_Controller : ControllerBase
    {
        private readonly ILogger<Alunos_Controller> _logger;
        public Alunos_Controller(ILogger<Alunos_Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet("SelectAllAlunos")]
        public async Task<ActionResult<List<Alunos>>> Get()
        {
            return new OracleConnections().selectAlunos();
        }
        [HttpPost("AllAlunos")]
        public async Task<ActionResult<Alunos>> Post(Alunos alunos)
        {
            new OracleConnections().AddStudent(alunos);
            return alunos;
        }

    }
}
