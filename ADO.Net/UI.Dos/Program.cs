using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection minhaConexao = new SqlConnection(@"data source = ANDRADE-PC;
            Integrated Security=SSPI; Initial Catalog = AulasCsharp");

            try
            {
                minhaConexao.Open();
            }
            catch (Exception)
            {

                throw;
            }


            //string queryUpdate = "UPDATE ALUNO SET Nome = 'Maria da Silva Selvagem' WHERE AlunoId = 1";
            //SqlCommand comandoUpdate = new SqlCommand(queryUpdate, minhaConexao);
            //comandoUpdate.ExecuteNonQuery();

            //string queryDelete = "DELETE FROM Aluno WHERE AlunoId = 2";
            //SqlCommand comandoDelete = new SqlCommand(queryDelete, minhaConexao);
            //comandoDelete.ExecuteNonQuery();

            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome da mae do aluno: ");
            string mae = Console.ReadLine();

            Console.Write("Digite a data de nascimento do aluno");
            string data = Console.ReadLine();

            string queryInsert = string.Format("INSERT INTO Aluno (Nome, Mae, DataNascimento) VALUES " +
               "('{0}', '{1}', '{2}')", nome, mae, data);

            SqlCommand comandoInsert = new SqlCommand(queryInsert, minhaConexao);
            comandoInsert.ExecuteNonQuery();

            string querySelect = "SELECT * FROM Aluno";
            SqlCommand cmd = new SqlCommand(querySelect, minhaConexao);
            SqlDataReader dados = cmd.ExecuteReader();


            while (dados.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Mãe: {2},  DataNascimento: {3}", dados["AlunoId"],
                    dados["Nome"], dados["Mae"], dados["DataNascimento"]);
            }
            Console.ReadLine();

            string cmdInsert = "INSERT INTO Aluno (Nome, Mae, DataNascimento) VALUES ('Enzo Leal'," +
                " 'Silvana Leal', '27/10/2011')";

            cmd = new SqlCommand(cmdInsert, minhaConexao);

            cmd.ExecuteNonQuery();

            

        }
    }
}
