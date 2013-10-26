using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProjetoBloco.Modelo
{
    [Table("Avaliacao")]
    public class Avaliacao : IIdentificavel
    {
        public String Comentarios { get; set; }

        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public DateTime DataInicio
        {
            get;
            set;
        }

        public DateTime? DataTermino
        {
            get;
            set;
        }

        public Guid AlunoID { get; set; }
        public Guid QuestionarioID { get; set; }
        public Guid ModuloID { get; set; }

        [ForeignKey("AlunoID")]
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public virtual Aluno Aluno
        {
            get;
            set;
        }

        [ForeignKey("QuestionarioID")]
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public virtual Questionario Questionario
        {
            get;
            set;
        }

        [ForeignKey("ModuloID")]
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public virtual Modulo Modulo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get;
            set;
        }

        public virtual ICollection<Resposta> Respostas { get; set; }

    }
}
