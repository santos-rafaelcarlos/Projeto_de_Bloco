using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.DAO
{
    public class QuestionarioDAO : DaoGenerico<Questionario>
    {
        public QuestionarioDAO(ProjetoContext context)
            : base(context)
        {

        }

        public override IQueryable<Questionario> BuscarTodos()
        {
            return _context.Questionario.AsQueryable();
        }

        public override Questionario Buscar(Guid id)
        {
            return _context.Questionario.FirstOrDefault(e => e.Id == id);
        }

        public override void Inserir(Questionario entity)
        {
            _context.Questionario.Add(entity);
            SalvarTudo();
        }

        public override void Deletar(Questionario entity)
        {
            _context.Questionario.Remove(entity);
            SalvarTudo();
        }
    }
}
