
namespace ProjetoBloco.Modelo
{
    public class Administrador : IPessoa, IUsuario
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
    }
}
