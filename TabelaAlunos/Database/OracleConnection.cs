using Oracle.ManagedDataAccess.Client;
using TabelaAlunos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TabelaAlunos.Database
{
    //Faz a herança do Indice DataBase
    public class OracleConnections : Database
    {

        //Abre uma String de Conexão
        const string CONSTRING = "User Id = SYSTEM; Password = 123456;" + "Data Source =192.168.15.23:1521/xe ";
        OracleCommand cmd;
        OracleConnection connection;


        //Abre uma conexão com o Banco de Dados Oracle 
        public void OpenConnection()
        {
            connection = new(CONSTRING);
            cmd = connection.CreateCommand();
            connection.Open();
            cmd.BindByName = true;
        }


        //Cria uma Lista que pega todos os dados do banco, e implementa nela
        public List<Alunos> selectAlunos()
        {
            OpenConnection();
            List<Alunos> listaAlunos = new();
            //Faz a conexão com a Procedure (conectando com o Cursor da Procedure)
            cmd.CommandText = "ALUNOS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("cur", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();

            //Laço de Repetição para implementar os dados do Banco de Dados na lista de Alunos (Lista que foi criada na linha 34)
            while (reader.Read())
            {
                listaAlunos.Add(new Alunos(Nome: reader.GetString("ALU_NM"), Numero: reader.GetString("ALU_NR_TEL"), Aniversario: DateTime.Parse(reader.GetString("ALU_DT_NASCIMENTO"))));
            }
            reader.Dispose();
            connection.Close();//Fecha Conexão

            return listaAlunos;//Retorna a lista
        }


        // Metodo para implementação de alunos no Banco de Dados
        public void addAlunos(Alunos newAlunos)
        {

            //Faz o incremento de Id, para que sempre pegue o ultimo numero e some 1
            var IdAlunos = (selectAlunos().Count + 1);

            OpenConnection();

            //Faz conexão com a procedure de AddAlunos, e faz a implementação dos dados no Bando de Dados
            cmd.CommandText = "ADDALUNOS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("NewALU_Id", IdAlunos)).Direction = ParameterDirection.Input;
            cmd.Parameters.Add(new OracleParameter("NewALU_NM", newAlunos.NOME)).Direction = ParameterDirection.Input;
            cmd.Parameters.Add(new OracleParameter("NewALU_TEL_NUM", newAlunos.NUMERO)).Direction = ParameterDirection.Input;
            cmd.Parameters.Add(new OracleParameter("NewALU_DT_NASCIMENTO", newAlunos.ANIVERSARIO)).Direction = ParameterDirection.Input;
            cmd.ExecuteReader();

            connection.Dispose();
            connection.Close();

        }

        //Metodo para Deletar um Aluno do Banco de Dados
        public void delAlunos(int delete_id)
        {

            OpenConnection();
            //Conecta com a Procedure de Delete, e faz o decremento de alunos do Banco do Dados
            cmd.CommandText = "DELALUNOS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("del_id", delete_id)).Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();
           
            connection.Dispose();
            connection.Close();
        }
    }
}
