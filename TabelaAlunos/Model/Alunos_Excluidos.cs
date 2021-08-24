using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabelaAlunos.Model
{
    public class Alunos_Excluidos
    {
        private int id_ex;
        private string Nome_ex;
        private string Numero_ex;
        private DateTime Aniversario_ex;
        private DateTime data_de_cadastro_ex;

        public Alunos_Excluidos(int id_ex, string Nome_ex, string Numero_ex, DateTime Aniversario_ex, DateTime data_de_cadastro_ex)
        {
            this.id_ex = id_ex;
            this.Nome_ex = Nome_ex;
            this.Numero_ex = Numero_ex;
            this.Aniversario_ex = Aniversario_ex;
            this.DATA_DE_CADASTRO_ex = data_de_cadastro_ex;
        }

        public int Id_ex { get => id_ex; set => id_ex = value; }
        public string NOME_ex { get => Nome_ex; set => Nome_ex = value; }
        public string NUMERO_ex { get => Numero_ex; set => Numero_ex = value; }
        public DateTime ANIVERSARIO_ex { get => Aniversario_ex; set => Aniversario_ex = value; }
        public DateTime DATA_DE_CADASTRO_ex { get => data_de_cadastro_ex; set => data_de_cadastro_ex = value; }
    }
}





