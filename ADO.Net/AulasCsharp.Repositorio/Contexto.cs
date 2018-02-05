using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulasCsharp.RepositorioADO
{
    public class Contexto : IDisposable
    {
        public readonly SqlConnection minhaConexao;

        public Contexto()

        {
            minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["AulasCsharpConfig"].ConnectionString);
            try
            {
                minhaConexao.Open();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // todo o resto sem retorno
        public void ExecutaComando(string query)
        {
            var cmdComando = new SqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = minhaConexao,
            };

            cmdComando.ExecuteNonQuery();
        }

        // apenas para selects
        public SqlDataReader ExecutaComandoComRetorno(string query)
        {
            var cmdComando = new SqlCommand(query, minhaConexao);

            return cmdComando.ExecuteReader();
        }


        public void Dispose()
        {
            if (minhaConexao.State == ConnectionState.Open)
                minhaConexao.Close();
        }
    }
}
