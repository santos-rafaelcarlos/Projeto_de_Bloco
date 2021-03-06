﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetoBloco.Modelo
{
    [Table("Modulo")]
    public class Modulo : IIdentificavel
    {
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public String Nome { get; set; }

        [ForeignKey("ProfessorID")]        
        public virtual Professor Professor { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id
        {
            get;
            set;
        }

        public virtual ICollection<Aluno> Alunos
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public Guid ProfessorID { get; set; }
        [Required(ErrorMessage = "Nome não pode ser branco.")]
        public Guid CursoID { get; set; }

        [ForeignKey("CursoID")]        
        public virtual Curso Curso
        {
            get;
            set;
        }
    }
}
