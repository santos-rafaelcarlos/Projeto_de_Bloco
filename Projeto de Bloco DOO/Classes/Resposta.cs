using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBloco.Modelo
{
    [Table("Resposta")]
    public class Resposta: IIdentificavel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get;
            set;
        }

        public Resposta()
        {
            Valor = (Int32)Escala.SemResposta;
        }

        /// <summary>
        /// 
        /// </summary>
        private Escala valor;
        public Int32 Valor
        {
            get { return (Int32)valor; }
           private set { valor = (Escala)value; }
        }

        public void EscolherResposta(Escala _resposta)
        {
            Valor = (Int32)_resposta;
        }

        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public Guid AvaliacaoID { get; set; }
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public Guid QuestaoID { get; set; }


        [ForeignKey("AvaliacaoID")]        
        public virtual Avaliacao Avaliacao { get; set; }


        [ForeignKey("QuestaoID")]        
        public virtual Questao Questao { get; set; }

        public DateTime DataResposta { get; set; }
    }
}
