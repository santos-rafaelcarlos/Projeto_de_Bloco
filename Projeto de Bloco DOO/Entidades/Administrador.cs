using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_de_Bloco_DOO.Interfaces;

namespace ProjetoBlocoDOO.Modelo
{
    public class Administrador : IPessoa, IUsuario
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
    }
}
