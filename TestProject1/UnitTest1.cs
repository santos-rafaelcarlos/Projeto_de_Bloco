using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;
using ProjetoBlocoDOO.DaoEF;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProjetoContext context = new ProjetoContext();
            Aluno a = new Aluno()
            {
                Id = Guid.NewGuid(),
                Login = "carlos.santos",
                Matricula = 1,
                Nome = "Rafael",
                Senha = "abc123",
            };


            DaoGenerico<Aluno> dao = new DaoGenerico<Aluno>(context);
            dao.Insert(a);

        }
    }
}
