
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ProjetoBloco.Modelo
{
    [Table("Administrador")]
    public class Administrador : IPessoa, IUsuario
    {
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public string Login
        {
            get;
            set;
        }
       
    }
}
