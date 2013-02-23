using System;

namespace ProjetoBloco.Modelo
{
    public class Aluno : IPessoa, IUsuario
    {

        public string Login
        {
            get;
            set;
        }


        public string Senha
        {
            get;
            set;
        }


        public Int32 Matricula
        {
            get;
            set;
        }
    }
}
