using LysisBI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LysisBI.Repository
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("PgImHere")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
        }

        public DbSet<usuario> Usuario { get; set; }

        public DbSet<Aula> Aula { get; set; }

        public DbSet<Professor> Professor { get; set; }

        public DbSet<Turma> Turma { get; set; }

        public DbSet<Frequencia> Frequencia { get; set; }

        public DbSet<Aluno> Aluno { get; set; }


    }
}