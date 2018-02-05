using AulasCsharp.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulasCsharp.RepositorioEntityFramework
{
    public class Contexto : DbContext
    {
        public Contexto(): base("AulasCsharpConfig")
        {

        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Aluno>().Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(80);
            modelBuilder.Entity<Aluno>().Property(x => x.Mae).IsRequired().HasColumnType("varchar").HasMaxLength(80);
            modelBuilder.Entity<Aluno>().Property(x => x.DataNascimento).IsRequired().HasColumnType("date");


            base.OnModelCreating(modelBuilder);
        }
    }
}
