using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.DaoEF;
using ProjetoBloco.Modelo;
using ProjetoBloco.Repository;
using ProjetoBloco.Factory;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Professor item = Fabrica.Criar(1, "Aquino", "aquino.botelho@infnet.edu.br");

            RepositorioGenerico<Professor>.Salvar(item);
        }
    }
}
