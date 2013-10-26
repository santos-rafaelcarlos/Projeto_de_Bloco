using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBloco.Modelo
{
    [Table("Pessoa")]
    public abstract class IPessoa : IIdentificavel
    {
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public String Email { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get;
            set;
        }
    }
}
