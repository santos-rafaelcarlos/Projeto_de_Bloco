using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBlocoDOO.Modelo;

namespace Projeto_de_Bloco_DOO.Interfaces
{
    public abstract class IPessoa : IIdentificavel
    {        
        public String Nome { get; set; }
        public String Email { get; set; }


        public Guid Id
        {
            get;
            set;
        }
    }
}
