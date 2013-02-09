using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_de_Bloco_DOO.Objetos_de_Valor;

namespace ProjetoBlocoDOO.Modelo
{
    public class Curso:IIdentificavel
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    }
}
