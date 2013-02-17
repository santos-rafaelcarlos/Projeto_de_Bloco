﻿using System.Data.Entity;
using ProjetoBloco.Modelo;


namespace ProjetoBloco.DaoEF
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(string connectionString)
            : base(connectionString)
        {
            
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questao>().HasRequired(q => q.Questionario).WithMany(q => q.Questoes).WillCascadeOnDelete(true);
            
            modelBuilder.Entity<Aluno>().HasKey(a => a.Id).ToTable("Aluno");
            modelBuilder.Entity<Administrador>().HasKey(a => a.Id).ToTable("Administrador");

            modelBuilder.Entity<Avaliacao>().HasKey(a => a.Id).ToTable("Avaliacao");
            modelBuilder.Entity<Questionario>().HasKey(a => a.Id).ToTable("Questionario");
            modelBuilder.Entity<Questao>().HasKey(a => a.Id).ToTable("Questao");
            modelBuilder.Entity<IPessoa>().HasKey(a => a.Id).ToTable("Pessoa");
            modelBuilder.Entity<Modulo>().HasKey(a => a.Id).ToTable("Modulo");
            modelBuilder.Entity<Curso>().HasKey(a => a.Id).ToTable("Curso");
            modelBuilder.Entity<Professor>().HasKey(a => a.Id).ToTable("Professor");


            base.OnModelCreating(modelBuilder);
        }
    }
}
