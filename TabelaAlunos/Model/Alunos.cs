using System;


namespace TabelaAlunos.Model
{
    public class Alunos
    {
        //private int id;
        private string Nome;
        private string Numero;
        private DateTime Aniversario;

        public Alunos(string Nome, string Numero, DateTime Aniversario)
        {
            //this.Id = id;
            this.NOME = Nome;
            this.NUMERO = Numero;
            this.ANIVERSARIO = Aniversario;
        }


        //public int Id { get => id; set => id = value; }
        public string NOME { get => Nome; set => Nome = value; }
        public string NUMERO { get => Numero; set => Numero = value; }
        public DateTime ANIVERSARIO { get => Aniversario; set => Aniversario = value; }

    }
}
