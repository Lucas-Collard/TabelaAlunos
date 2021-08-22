using System.Collections.Generic;
using TabelaAlunos.Model;

namespace TabelaAlunos.Repository
{
    public interface RepositoryImplementation
    {
        void OpenConnection();
        List<Alunos> selectAlunos();
        void addAlunos(Alunos newAlunos);
       

    }
}
