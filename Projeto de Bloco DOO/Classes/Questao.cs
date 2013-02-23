using System;

namespace ProjetoBloco.Modelo
{
    public class Questao :IIdentificavel
    {
        public Questao()
        {

        }

        public Questao(Guid _id, string _texto)
        {
            Id = _id;
            Texto = _texto;
            Resposta = (Int32)ProjetoBloco.Modelo.Resposta.SemResposta;
        }


        public Guid Id
        {
            get;
            set;
        }
        
        /// <summary>
        /// Texto da questão
        /// </summary>

        public String Texto
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        private Resposta resposta;
        public Int32 Resposta
        {
            get { return (Int32)resposta; }
            private set { resposta = (Resposta)value; }
        }

        public void EscolherResposta(Resposta _resposta)
        {
            Resposta = (Int32)_resposta;
        }

        public Questionario Questionario { get; set; }
    }
}
