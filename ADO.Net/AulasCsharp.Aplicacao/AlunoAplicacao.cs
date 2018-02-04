using AulasCsharp.Dominio;
using AulasCsharp.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulasCsharp.Aplicacao
{
    public class AlunoAplicacao
    {
        private Contexto contexto;

        public void Inserir(Aluno aluno)
        {
            var query = "";
            query += " INSERT INTO Aluno (Nome, Mae, DataNascimento) ";
            query += string.Format(" VALUES ('{0}','{1}','{2}')", aluno.Nome, aluno.Mae, aluno.DataNascimento);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(query);
            }
        }

        public void Alterar(Aluno aluno, int Id)
        {
            var query = "";
            query += " UPDATE ALUNO SET ";
            query += string.Format(" Nome = '{0}', ", aluno.Nome);
            query += string.Format(" Mae = '{0}', ", aluno.Mae);
            query += string.Format(" DataNascimento = '{0}'", aluno.DataNascimento);
            query += string.Format(" WHERE AlunoId = {0} ", Id);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(query);
            }
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var query = string.Format(" DELETE FROM ALUNO WHERE AlunoId = {0}", id);
                contexto.ExecutaComando(query);
            }
        }

        public List<Aluno> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                string query = " SELECT * FROM ALUNO";
                SqlDataReader retornoDataReader = contexto.ExecutaComandoComRetorno(query);
                return TransformaReaderEmList(retornoDataReader);
            }
        }

        public Aluno ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                string query = string.Format(" SELECT * FROM ALUNO WHERE AlunoId = {0}", id);
                SqlDataReader retornoDataReader = contexto.ExecutaComandoComRetorno(query);
                return TransformaReaderEmList(retornoDataReader).FirstOrDefault();
            }
        }

        public List<Aluno> TransformaReaderEmList(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var tempObjeto = new Aluno
                {
                    Id = int.Parse(reader["AlunoId"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Mae = reader["Mae"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString())
                };

                alunos.Add(tempObjeto);
            }
            reader.Close();
            return alunos;

        }
    }

}
