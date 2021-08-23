using System;


namespace TabelaAlunos.Model
{
    public class Alunos
    {

        private string Nome;
        private string Numero;
        private DateTime Aniversario;

        public Alunos(string Nome, string Numero, DateTime Aniversario)
        {
            this.NOME = Nome;
            this.NUMERO = Numero;
            this.ANIVERSARIO = Aniversario;
        }

        public string NOME { get => Nome; set => Nome = value; }
        public string NUMERO { get => Numero; set => Numero = value; }
        public DateTime ANIVERSARIO { get => Aniversario; set => Aniversario = value; }

    }
}
