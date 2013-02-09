﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ProjetoBlocoDOO.Modelo.Entidades;
using ProjetoBlocoDOO.Modelo;
using Projeto_de_Bloco_DOO.Interfaces;
using Projeto_de_Bloco_DOO.Objetos_de_Valor;

namespace Projeto_de_Bloco_DOO.Entity
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext()
            : base("Server=(Local);Database=Projeto;Trusted_Connection=true;")
        {
            string s = Database.Connection.ConnectionString;
        }

        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Questionario> Questionario { get; set; }
        public DbSet<Questao> Questao { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<IPessoa> Pessoa { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

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
