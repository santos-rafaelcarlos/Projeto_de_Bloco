using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBloco.Modelo
{
    [Table("Curso")]
    public class Curso:IIdentificavel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public string Nome
        {
            get;
            set;
        }
    }
}
