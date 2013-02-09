using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBlocoDOO.Modelo
{
    public class Questionario:IIdentificavel
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// criador do questionário
        /// </summary>
        private Administrador criador;
        public Administrador Criador
        {
            get { return criador; }
            set { criador = value; }
        }


        /// <summary>
        /// Questões que compõem o questionário
        /// </summary>
        ICollection<Questao> questoes;
        public ICollection<Questao> Questoes
        {
            get { return questoes; }
            set { questoes = value; }
        }
    }
}
