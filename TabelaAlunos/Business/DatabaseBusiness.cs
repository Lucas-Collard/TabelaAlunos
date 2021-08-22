using System.Collections.Generic;
using TabelaAlunos.Model;

namespace TabelaAlunos.Business
{
    public interface DatabaseBusiness
    {
        void OpenConnection();
        List<Alunos> selectAlunos();
        void addAlunos(Alunos newAlunos);
       

    }
}
