using System.Collections.Generic;
using TabelaAlunos.Model;

namespace TabelaAlunos.Database
{
    public interface Database
    {
        void OpenConnection();
        List<Alunos> selectAlunos();
        void addAlunos(Alunos newAlunos);
       // void DelAlunos(int delete_id);

    }
}
