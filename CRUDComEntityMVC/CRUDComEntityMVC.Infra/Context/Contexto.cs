using CRUDComEntityMVC.Infra.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CRUDComEntityMVC.Infra.Context
{
    public class Contexto : DbContext
    {
        public Contexto() : base("CRUDComEntityMVC")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();



            base.OnModelCreating(modelBuilder);
        }

    }
}