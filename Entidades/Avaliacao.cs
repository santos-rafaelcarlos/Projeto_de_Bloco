using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBlocoDOO.Modelo.Entidades
{
    public class Avaliacao:IIdentificavel
    {
        private string identificador;
        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }

        private string objetivoDaAvaliacao;
        public string ObjetivoDaAvaliacao
        {
            get { return objetivoDaAvaliacao; }
            set { objetivoDaAvaliacao = value; }
        }

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

        private Respondente respondente;
        public Respondente Respondente
        {
            get { return respondente; }
            set { respondente = value; }
        }

        private Questionario questionario;
        public Questionario Questionario
        {
            get { return questionario; }
            set { questionario = value; }
        }

        private Turma turma;
        public Turma Turma
        {
            get { return turma; }
            set { turma = value; }
        }

        private Professor professor;
        public Professor Professor
        {
            get { return professor; }
            set { professor = value; }
        }

        private Curso curso;
        public Curso Curso
        {
            get { return curso; }
            set { curso = value; }
        }

        public Guid Id
        {
            get;
            set;
        }
    }
}
