using AulasCsharp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulasCsharp.RepositorioEntityFramework
{
    public class AlunoRepositorioEF : IRepositorio<Aluno>
    {

        private readonly Contexto contexto;

        public AlunoRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Excluir(Aluno entidade)
        {
            var alunoExcluir = contexto.Alunos.First(x => x.Id == entidade.Id);
            contexto.Set<Aluno>().Remove(alunoExcluir);
            contexto.SaveChanges();
           
        }

        public Aluno ListarPorId(string id)
        {
            int idInt;
            int.TryParse(id, out idInt);

            return contexto.Alunos.First(x => x.Id == idInt);
            
        }

        public IEnumerable<Aluno> ListarTodos()
        {
            return contexto.Alunos;
        }

        public void Salvar(Aluno entidade)
        {
            if (entidade.Id > 0)
            {
                var alunoAlterar = contexto.Alunos.First(x => x.Id == entidade.Id);
                alunoAlterar.Nome = entidade.Nome;
                alunoAlterar.Mae = entidade.Mae;
                alunoAlterar.DataNascimento = entidade.DataNascimento;
            }
            else
            {
                contexto.Alunos.Add(entidade);
            }
            contexto.SaveChanges();            
        }

        
    }
}
