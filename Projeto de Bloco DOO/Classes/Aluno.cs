using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBloco.Modelo
{
    [Table("Aluno")]
    public class Aluno : IPessoa, IUsuario
    {
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public string Login
        {
            get;
            set;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Matricula
        {
            get;
            set;
        }

        public Guid ModuloID { get; set; }

        [ForeignKey("ModuloID")]
        public virtual Modulo Modulo { get; set; }
    }
}
