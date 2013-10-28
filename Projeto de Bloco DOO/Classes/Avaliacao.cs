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

        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public Guid AlunoID { get; set; }

        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public Guid QuestionarioID { get; set; }

        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public Guid ModuloID { get; set; }

        [ForeignKey("AlunoID")]        
        public virtual Aluno Aluno
        {
            get;
            set;
        }

        [ForeignKey("QuestionarioID")]
        public virtual Questionario Questionario
        {
            get;
            set;
        }

        [ForeignKey("ModuloID")]
        public virtual Modulo Modulo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get;
            set;
        }

        public virtual ICollection<Resposta> Respostas { get; set; }

        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public Guid CriadorID { get; set; }
        
        /// <summary>
        /// criador do questionário
        /// </summary>
        [ForeignKey("CriadorID")]
        public virtual Administrador Criador
        {
            get;
            set;
        }

    }
}
