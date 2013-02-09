using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBlocoDOO.Modelo
{
    public class Responder
    {
        private Respondente respondente;
        private Questao questao;

        public Responder(Respondente _respondente, Questao _questao)
        {
            respondente = _respondente;
            questao = _questao;
        }

        public void ResponderQuestao(Resposta _resposta)
        {
            questao.EscolherResposta(_resposta);
        }
    }
}
