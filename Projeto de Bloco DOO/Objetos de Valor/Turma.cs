using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBlocoDOO.Modelo
{
    public class Turma : IIdentificavel
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nome { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
