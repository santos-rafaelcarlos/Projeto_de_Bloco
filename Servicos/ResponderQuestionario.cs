using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBlocoDOO.Modelo;

namespace Projeto_de_Bloco_DOO.Servicos
{
    class ResponderQuestionario
    {
        private Respondente respondente;
        private Questionario questionario;

        public ResponderQuestionario(Respondente _respondente, Questionario _questionario)
        {
            respondente = _respondente;
            questionario = _questionario;
        }

        public void ResponderQuestionario()
        {
            foreach (var item in questionario.Questoes)
            {
                Responder responder = new Responder(respondente, item);

                
            }
        }
    }
}
