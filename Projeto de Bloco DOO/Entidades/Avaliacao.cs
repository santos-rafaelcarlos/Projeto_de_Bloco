using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_de_Bloco_DOO.Objetos_de_Valor;

namespace ProjetoBlocoDOO.Modelo.Entidades
{
    public class Avaliacao:IIdentificavel
    {
        private string identificador;

        private string objetivoDaAvaliacao;

        private DateTime dataInicio;
        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        private DateTime dataTermino;
        public DateTime DataTermino
        {
            get { return dataTermino; }
            set { dataTermino = value; }
        }


        public Aluno Aluno
        {
            get;
            set;
        }

        private Questionario questionario;
        public Questionario Questionario
        {
            get { return questionario; }
            set { questionario = value; }
        }

        private Turma turma;

        private Professor professor;

        private Curso curso;

        public Modulo Modulo { get; set; }

        public Guid Id
        {
            get;
            set;
        }
    }
}
