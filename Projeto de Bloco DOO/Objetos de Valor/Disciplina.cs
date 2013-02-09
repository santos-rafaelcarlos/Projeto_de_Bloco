using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBlocoDOO.Modelo;

namespace Projeto_de_Bloco_DOO.Objetos_de_Valor
{
    public class Modulo: IIdentificavel
    {
        public String Nome { get; set; }

        public Professor Professor { get; set; }

        public Guid Id
        {
            get;
            set;
        }

        public List<ProjetoBlocoDOO.Modelo.Aluno> Alunos
        {
            get;
            set;
        }

        public Curso Curso
        {
            get;
            set;
        }
    }
}
