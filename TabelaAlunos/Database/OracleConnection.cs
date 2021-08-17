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
            cmd.CommandText = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("cur", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listaAlunos.Add(new Alunos(alu_nm: reader.GetString("ALU_NM"), alu_tel_num: reader.GetString("ALU_TEL_NUM"), alu_nascimento: DateTime.Parse(reader.GetString("ALU_NASCIMENTO"))));
            }
            reader.Dispose();
            connection.Close();
            
            return listaAlunos;

        }

        public void addAlunos(Alunos newAlunos)
        {
            var AlunoId = (selectAlunos().Count + 1);

            OpenConnection();


            //Confirmar com o Samuel pra que serve essa parte

            //cmd.CommandText = "sp_AddStudent";
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.Add(new OracleParameter("id_NewStudent", studentId)).Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(new OracleParameter("name_NewStudent", newStudent.Alu_Nm)).Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(new OracleParameter("cel_NewStudent", newStudent.Alu_Tel_Num)).Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(new OracleParameter("birthdate_NewStudent", newStudent.Alu_Nascimento)).Direction = ParameterDirection.Input;
            //cmd.ExecuteReader();

            connection.Dispose();
            connection.Close();
        }
        


    }
}
