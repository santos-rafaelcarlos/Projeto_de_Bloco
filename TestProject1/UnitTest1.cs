using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoBlocoDOO.Modelo.Entidades;
using ProjetoBlocoDOO.Modelo;
using Projeto_de_Bloco_DOO.Interfaces;
using Projeto_de_Bloco_DOO.Objetos_de_Valor;
using Projeto_de_Bloco_DOO.Entity;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProjetoContext context = new ProjetoContext();
            context.Aluno.Add(new Aluno() {
                Id  = Guid.NewGuid(),
                Login = "carlos.santos",
                Matricula = 1,
                Nome = "Rafael",
                Senha = "abc123",
            });

            //context.SaveChanges();

        }
    }
}
