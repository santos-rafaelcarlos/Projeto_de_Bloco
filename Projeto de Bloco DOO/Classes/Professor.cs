
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace ProjetoBloco.Modelo
{
    [Table("Professor")]
    public class Professor : IPessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Matricula { get; set; }
    }
}
