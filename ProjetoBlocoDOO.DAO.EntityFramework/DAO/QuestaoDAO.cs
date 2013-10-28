using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;
using System.Data.SqlClient;

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
            return _context.Questao.Find(id);
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
