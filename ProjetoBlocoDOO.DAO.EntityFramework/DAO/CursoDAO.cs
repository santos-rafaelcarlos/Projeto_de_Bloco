using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.DaoEF;
using ProjetoBloco.Modelo;

namespace ProjetoBloco.DAO
{
    public class CursoDAO : DaoGenerico<Curso>
    {
        public CursoDAO(ProjetoContext context):base(context)
        {

        }
        
        public override IQueryable<Curso> BuscarTodos()
        {
            return _context.Curso.AsQueryable();
        }

        public override Curso Buscar(Guid id)
        {
            return _context.Curso.Find(id);
        }

        public override void Inserir(Curso entity)
        {
            _context.Curso.Add(entity);
            SalvarTudo();
        }

        public override void Deletar(Curso entity)
        {
            _context.Curso.Remove(entity);
            SalvarTudo();
        }
    }
}
