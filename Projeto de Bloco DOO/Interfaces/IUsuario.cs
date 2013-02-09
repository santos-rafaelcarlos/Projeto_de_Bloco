using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBlocoDOO.Modelo
{
    public interface IUsuario : IIdentificavel
    {        
        string Login { get; set; }
        string Senha { get; set; }     

    }
}
