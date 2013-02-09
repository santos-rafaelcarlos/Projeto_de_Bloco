using System;
using System.Collections.Generic;

namespace ProjetoBloco.Modelo
{
    public class Questionario:IIdentificavel
    {       

        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// criador do questionário
        /// </summary>

        public Administrador Criador
        {
            get;
            set;
        }


        /// <summary>
        /// Questões que compõem o questionário
        /// </summary>        
        public ICollection<Questao> Questoes
        {
            get;
            set;
        }
    }
}
