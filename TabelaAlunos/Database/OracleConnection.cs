using Oracle.ManagedDataAccess.Client;
using TabelaAlunos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TabelaAlunos.Database
{
    public class OracleConnections : Database
    {
        const string CONSTRING = "User Id = SYSTEM; Password = 123456;" + "Data Source =192.168.15.23:1521/xe ";
        OracleCommand cmd;
        OracleConnection connection;

        public void OpenConnection()
        {
            connection = new(CONSTRING);
            cmd = connection.CreateCommand();
            connection.Open();
            cmd.BindByName = true;
        }

        public List<Alunos> selectAlunos()
        {
            OpenConnection();
            List<Alunos> listaAlunos = new();

            cmd.CommandText = "ALUNOS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("cur", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listaAlunos.Add(new Alunos(Nome: reader.GetString("ALU_NM"), Numero: reader.GetString("ALU_NR_TEL"), Aniversario: DateTime.Parse(reader.GetString("ALU_DT_NASCIMENTO"))));
            }
            reader.Dispose();
            connection.Close();

            return listaAlunos;
        }



        public void addAlunos(Alunos newAlunos)
        {
            var IdAlunos = (selectAlunos().Count + 1);

            OpenConnection();


            //Confirmar com o Samuel pra que serve essa parte

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
        public void delAlunos(int delete_id)
        {

            OpenConnection();

            cmd.CommandText = "DELALUNOS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("del_id", delete_id)).Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();
           
            connection.Dispose();
            connection.Close();
        }
    }
}
