using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;
using ProjetoBloco.Repository;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RepositorioGenerico<Questao>.Salvar(new Questao() { Texto = "TEst" });
        }
    }
}
