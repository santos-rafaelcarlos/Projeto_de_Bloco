using System;
using System.Collections.Generic;

namespace ProjetoBloco.Modelo
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

        public List<Aluno> Alunos
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
