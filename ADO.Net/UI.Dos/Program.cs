using AulasCsharp.Aplicacao;
using AulasCsharp.Dominio;
using AulasCsharp.Repositorio;
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
            var contexto = new Contexto();
            

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

            Aluno aluno = new Aluno
            {
                Nome = nome,
                Mae = mae,
                DataNascimento = DateTime.Parse(data)
            };

            new AlunoAplicacao().Inserir(aluno);

            Console.WriteLine("Informe o ID do aluno a ser alterado");

            int IdEscolhido = int.Parse(Console.ReadLine());


            Console.Write("Digite o nome do aluno: ");
            string nomeAlterado = Console.ReadLine();

            Console.Write("Digite o nome da mae do aluno: ");
            string maeAlterado = Console.ReadLine();

            Console.Write("Digite a data de nascimento do aluno");
            string dataAlterado = Console.ReadLine();

            Aluno alunoAlterado = new Aluno
            {
                Nome = nomeAlterado,
                Mae = maeAlterado,
                DataNascimento = DateTime.Parse(dataAlterado)
            };

            new AlunoAplicacao().Alterar(alunoAlterado, IdEscolhido);

            var dados = new AlunoAplicacao().ListarTodos();

            foreach (var alunoreg in dados)
            {

                Console.WriteLine("Id: {0}, Nome: {1}, Mãe: {2},  DataNascimento: {3}", alunoreg.Id,
                    alunoreg.Nome, alunoreg.Mae, alunoreg.DataNascimento);
            }
            
            Console.ReadLine();
      

            

        }
    }
}
