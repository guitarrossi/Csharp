using CRUDComEntityMVC.Infra.Context;
using CRUDComEntityMVC.Infra.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CRUDComEntityMVC.Infra.Repository
{
    public class UsuarioRepository
    {
        private readonly Contexto _contexto;

        public UsuarioRepository()
        {
            _contexto = new Contexto();
        }

        public void Salvar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return _contexto.Usuario.ToList();
        }

        public Usuario ListarPorId(int? id)
        {
            return _contexto.Usuario.Find(id);
        }

        public void Atualizar(Usuario usuario)
        {
            _contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(int id)
        {
            var usuario = ListarPorId(id);
            _contexto.Usuario.Remove(usuario);
            _contexto.SaveChanges();
        }
    }
}
