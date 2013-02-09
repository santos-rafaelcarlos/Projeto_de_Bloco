using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBlocoDOO.Modelo
{
    public class Professor : IUsuario
    {        
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

    }
}
