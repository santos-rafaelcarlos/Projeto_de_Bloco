using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBloco.Modelo
{
    [Table("Questao")]
    public class Questao : IIdentificavel
    {
        public Questao()
        {

        }

        public Questao(string _texto)
        {   
            Texto = _texto;          
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Texto da questão
        /// </summary>

        public String Texto
        {
            get;
            set;
        }
        
        public Guid? QuestionarioID { get; set; }

        [InverseProperty("ID")]
        [ForeignKey("QuestionarioID")]        
        public virtual Questionario Questionario { get; set; }
    }
}
