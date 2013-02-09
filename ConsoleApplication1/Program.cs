using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.DaoEF;
using ProjetoBloco.Modelo;
using ProjetoBlocoDOO.Repository;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {            
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
            Console.ReadKey();
        }
    }
}
