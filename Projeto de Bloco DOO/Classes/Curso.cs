using System;

namespace ProjetoBloco.Modelo
{
    public class Curso:IIdentificavel
    {

        public Guid Id
        {
            get;
            set;
        }


        public string Nome
        {
            get;
            set;
        }
    }
}
