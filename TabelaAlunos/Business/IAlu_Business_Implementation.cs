using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabelaAlunos.Model;
using TabelaAlunos.Repository;

namespace TabelaAlunos.Business
{

    public class IAlu_Business_Implementation : IAlu_Business
    {
        private readonly IAlu_Repository _AluRepository;
        public IAlu_Business_Implementation(IAlu_Repository aluRepository)
        {
            _AluRepository = aluRepository;
        }

        public ActionResult<Alunos> addAlunos(Alunos newAlunos)
        {
            return _AluRepository.addAlunos(newAlunos);
        }

        public void delAlunos(int delete_id)
        {
            _AluRepository.delAlunos(delete_id);
        }

        public List<Alunos> selectAlunos()
        {
            return _AluRepository.selectAlunos();
        }
    }
}
