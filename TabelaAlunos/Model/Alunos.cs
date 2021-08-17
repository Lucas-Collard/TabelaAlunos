using System;


namespace TabelaAlunos.Model
{
    public class Alunos
    {
        private string alu_nm;
        private string alu_tel_num;
        private DateTime alu_nascimento;

        public Alunos(string alu_nm, string alu_tel_num, DateTime alu_nascimento)
        {
            this.Alu_Nm = alu_nm;
            this.Alu_Tel_Num = alu_tel_num;
            this.Alu_Nascimento = alu_nascimento;
        }

        public string Alu_Nm { get => alu_nm; set => alu_nm = value; }
        public string Alu_Tel_Num { get => alu_tel_num; set => alu_tel_num = value; }
        public DateTime Alu_Nascimento { get => alu_nascimento; set => alu_nascimento = value; }
    }
}
