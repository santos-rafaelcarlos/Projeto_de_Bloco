using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ProjetoBloco.Modelo
{
    [Table("Questionario")]
    public class Questionario:IIdentificavel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get;
            set;
        }

        public Guid CriadorID { get; set; }

        public String Identificador { get; set; }

        /// <summary>
        /// criador do questionário
        /// </summary>
        [ForeignKey("CriadorID")]
        public virtual Administrador Criador
        {
            get;
            set;
        }


        /// <summary>
        /// Questões que compõem o questionário
        /// </summary>        
        public virtual ICollection<Questao> Questoes
        {
            get;
            set;
        }
    }
}
