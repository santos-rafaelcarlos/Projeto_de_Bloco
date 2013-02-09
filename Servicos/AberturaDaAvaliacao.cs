using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBlocoDOO.Modelo
{
    public class AberturaDaAvaliacao
    {
        private ICollection<Respondente> respondentes;
        private Questionario questionario;

        public AberturaDaAvaliacao(ICollection<Respondente> _respondentes,Questionario _questionario)
        {
            respondentes = _respondentes;
            questionario = _questionario;
        }

        public void AbrirAvaliacao()
        {
            foreach (var item in respondentes)
            {
                //Convidar para acesso ao questionário
            }
        }
    }
}
