using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.DaoEF;
using ProjetoBloco.Modelo;

namespace ProjetoBloco.DAO
{
    public class ModuloDAO : DaoGenerico<Modulo>
    {
        public ModuloDAO(ProjetoContext context)
            : base(context)
        {

        }


        public override IQueryable<Modulo> BuscarTodos()
        {
            return _context.Modulo.AsQueryable();
        }

        public override Modulo Buscar(Guid id)
        {
            Modulo item =_context.Modulo.Find(id);
            item.Professor = _context.Professor.Find(item.ProfessorID);
            item.Curso = _context.Curso.Find(item.CursoID);
            item.Alunos = _context.Aluno.Where(a=>a.ModuloID == id).ToList();
            
            return item;
        }

        public override void Inserir(Modulo entity)
        {
            _context.Modulo.Add(entity);
            SalvarTudo();
        }

        public override void Deletar(Modulo entity)
        {
            _context.Modulo.Remove(entity);
            SalvarTudo();
        }
    }
}
