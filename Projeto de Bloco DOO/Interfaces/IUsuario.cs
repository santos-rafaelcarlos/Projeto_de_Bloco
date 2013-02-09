
namespace ProjetoBloco.Modelo
{
    public interface IUsuario : IIdentificavel
    {        
        string Login { get; set; }
        string Senha { get; set; }     

    }
}
