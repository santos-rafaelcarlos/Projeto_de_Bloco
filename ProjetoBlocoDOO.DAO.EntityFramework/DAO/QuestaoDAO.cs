using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.DAO
{
    public class QuestaoDAO : DaoGenerico<Questao>
    {
        public QuestaoDAO(ProjetoContext context)
            :base(context)
        {
            
        }

        public override IQueryable<Questao> BuscarTodos()
        {
            return _context.Questao.AsQueryable();
        }

        public override Questao Buscar(Guid id)
        {
            return _context.Questao.FirstOrDefault(e => e.Id == id);
        }

        public override void Inserir(Questao entity)
        {
            _context.Questao.Add(entity);
            SalvarTudo();
        }

        public override void Deletar(Questao entity)
        {
            _context.Questao.Remove(entity);
            SalvarTudo();
        }
    }
}
