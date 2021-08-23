using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TabelaAlunos.Model;

namespace TabelaAlunos.Repository
{
    public interface IAlu_Repository
    {
        void OpenConnection();
        List<Alunos> selectAlunos();
        ActionResult<Alunos> addAlunos(Alunos newAlunos);
        void delAlunos(int delete_id);
    }
}
