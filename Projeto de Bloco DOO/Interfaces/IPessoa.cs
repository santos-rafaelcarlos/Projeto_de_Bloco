using System;

namespace ProjetoBloco.Modelo
{
    public abstract class IPessoa : IIdentificavel
    {        
        public String Nome { get; set; }
        public String Email { get; set; }


        public Guid Id
        {
            get;
            set;
        }
    }
}
