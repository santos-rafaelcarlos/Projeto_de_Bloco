﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;
using ProjetoBlocoDOO.DaoEF;
using ProjetoBlocoDOO.Repository;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string connString = "Server=santos_rcs-Note;Database=Projeto;Trusted_Connection=true;";

            ProjetoContext context = new ProjetoContext(connString);
            Aluno a = new Aluno()
            {
                Id = Guid.NewGuid(),
                Login = "carlos.santos",
                Matricula = 1,
                Nome = "Rafael",
                Senha = "abc123",
            };


            RepositorioGenerico<Aluno> repo = new RepositorioGenerico<Aluno>();
            repo.Salvar(a);

        }
    }
}
