using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBlocoDOO.Modelo
{
    public class Questao :IIdentificavel
    {
        public Questao(Guid _id, string _texto)
        {
            Id = _id;
            Texto = _texto;
            Resposta = ProjetoBlocoDOO.Modelo.Resposta.SemResposta;
        }

        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }
        
        /// <summary>
        /// Texto da questão
        /// </summary>
        private String texto;
        public String Texto
        {
            get { return texto; }
            private set { texto = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Resposta resposta;
        public Resposta Resposta
        {
            get { return resposta; }
            private set { resposta = value; }
        }


        public void EscolherResposta(Resposta _resposta)
        {
            Resposta = _resposta;
        }
    }
}
