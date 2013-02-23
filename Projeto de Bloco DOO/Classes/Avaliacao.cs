using System;

namespace ProjetoBloco.Modelo
{
    public class Avaliacao:IIdentificavel
    {
        public String Comentarios { get; set; }

        public DateTime DataInicio
        {
            get;
            set;
        }

        public DateTime? DataTermino
        {
            get;
            set;
        }


        public Aluno Aluno
        {
            get;
            set;
        }

        public Questionario Questionario
        {
            get;
            set;
        }
        
        public Modulo Modulo { get; set; }

        public Guid Id
        {
            get;
            set;
        }
    }
}
