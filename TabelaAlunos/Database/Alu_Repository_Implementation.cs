using Oracle.ManagedDataAccess.Client;
using TabelaAlunos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TabelaAlunos.Repository
{
    //Faz a herança do Indice DataBase
    public class Alu_Repository_Implementation : IAlu_Repository
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
            try
            {

                OpenConnection();
                List<Alunos> listaAlunos = new();
                //Faz a conexão com a Procedure (conectando com o Cursor da Procedure)
                cmd.CommandText = "prALU_SEL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("cur", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                //Laço de Repetição para implementar os dados do Banco de Dados na lista de Alunos (Lista que foi criada na linha 34)
                while (reader.Read())
                {

                    listaAlunos.Add(new Alunos(id: reader.GetInt32("ALU_ID"), Nome: reader.GetString("ALU_NM"), Numero: reader.GetString("ALU_NR_TEL"), Aniversario: DateTime.Parse(reader.GetString("ALU_DH_NASCIMENTO")), data_de_cadastro: DateTime.Parse(reader.GetString("ALU_DH_CADASTRO"))));

                }
                reader.Dispose();
                connection.Close();//Fecha Conexão

                return listaAlunos;//Retorna a lista
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();

                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }


        // Metodo para implementação de alunos no Banco de Dados
        public ActionResult<Alunos> addAlunos(Alunos newAlunos)
        {
            try
            {
                //Faz o incremento de Id, para que sempre pegue o ultimo numero e some 1
                var IdAlunos = (selectAlunos().Count + 1);

                OpenConnection();

                //Faz conexão com a procedure de AddAlunos, e faz a implementação dos dados no Bando de Dados
                cmd.CommandText = "prALU_INS";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("ALUNew_Id", IdAlunos)).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new OracleParameter("ALUNew_NM", newAlunos.NOME)).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new OracleParameter("ALUNew_TEL_NUM", newAlunos.NUMERO)).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new OracleParameter("ALUNew_DH_NASCIMENTO", newAlunos.ANIVERSARIO)).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new OracleParameter("ALUNew_DH_CADASTRO", newAlunos.DATA_DE_CADASTRO)).Direction = ParameterDirection.Input;
                cmd.ExecuteReader();

                connection.Dispose();
                connection.Close();

                return newAlunos;
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();

                throw ex;
            }
            finally
            {
                connection.Close();
            }


        }

        //Metodo para Deletar um Aluno do Banco de Dados
        public void delAlunos(int delete_id)
        {
            try
            {
                OpenConnection();
                DateTime localDate = DateTime.Now;

                //Conecta com a Procedure de Delete, e faz o decremento de alunos do Banco do Dados

                cmd.CommandText = "prALUBK_DEL";



                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("ALUEX_ID_DEL", delete_id)).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new OracleParameter("ALUBK_DH_EXCLU", localDate)).Direction = ParameterDirection.Input;


                cmd.ExecuteNonQuery();

                connection.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();

                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        public List<Alunos_Excluidos> selectAlunosEx()
        {
            try
            {
                OpenConnection();
                List<Alunos_Excluidos> listaAlunosEx = new();
                //Faz a conexão com a Procedure (conectando com o Cursor da Procedure)
                cmd.CommandText = "prALUEX_SEL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("cur_ex", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();

                //Laço de Repetição para implementar os dados do Banco de Dados na lista de Alunos (Lista que foi criada na linha 34)
                while (reader.Read())
                {

                    listaAlunosEx.Add(new Alunos_Excluidos(id_ex: reader.GetInt32("ALUBK_ID"), Nome_ex: reader.GetString("ALUBK_NM"), Numero_ex: reader.GetString("ALUBK_NR_TEL"), Aniversario_ex: DateTime.Parse(reader.GetString("ALUBK_DH_NASCIMENTO")), data_de_cadastro_ex: DateTime.Parse(reader.GetString("ALUBK_DH_CADASTRO"))));

                }
                reader.Dispose();
                connection.Close();//Fecha Conexão

                return listaAlunosEx;//Retorna a lista
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();

                throw ex ;
            }
            finally
            {
                connection.Close();
            }
            
        }
    }
}