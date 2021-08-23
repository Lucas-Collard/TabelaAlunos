using System;


namespace TabelaAlunos.Model
{
    public class Alunos
    {
        private int id;
        private string Nome;
        private string Numero;
        private DateTime Aniversario;
        private DateTime data_de_cadastro;

        public Alunos(int id, string Nome, string Numero, DateTime Aniversario, DateTime data_de_cadastro)
        {
            this.id = id;
            this.Nome = Nome;
            this.Numero = Numero;
            this.Aniversario = Aniversario;
            this.DATA_DE_CADASTRO = data_de_cadastro;
        }

       
        public DateTime DATA_DE_CADASTRO { get => data_de_cadastro; set => data_de_cadastro = value; }
        public int Id { get=>id; set=>id=value; }
        public string NOME { get => Nome; set => Nome = value; }
        public string NUMERO { get => Numero; set => Numero = value; }
        public DateTime ANIVERSARIO { get => Aniversario; set => Aniversario = value; }

    }
}


