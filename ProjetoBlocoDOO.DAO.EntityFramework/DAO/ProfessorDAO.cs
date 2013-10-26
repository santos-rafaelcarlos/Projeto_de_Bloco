using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.DAO
{
    public class ProfessorDAO : DaoGenerico<Professor>
    {
        public ProfessorDAO(ProjetoContext context)
            : base(context)
        {

        }
         
        public override IQueryable<Professor> BuscarTodos()
        {
            return _context.Professor.AsQueryable();
        }

        public override Professor Buscar(Guid id)
        {
            return _context.Professor.FirstOrDefault(e => e.Id == id);
        }

        public override void Inserir(Professor entity)
        {
            _context.Professor.Add(entity);
        }

        public override void Deletar(Professor entity)
        {
            _context.Professor.Remove(entity);
        }
    }
}
