using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabelaAlunos.Model;

namespace TabelaAlunos.Business
{
    public interface IAlu_Business
    {
        public List<Alunos> selectAlunos();

        public ActionResult<Alunos> addAlunos(Alunos newAlunos);

        public void delAlunos(int delete_id);

        public List<Alunos_Excluidos> selectAlunosEx();

    }


}
