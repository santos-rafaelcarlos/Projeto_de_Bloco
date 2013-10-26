using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.DAO
{
    public class AvaliacaoDAO : DaoGenerico<Avaliacao>
    {
        public AvaliacaoDAO(ProjetoContext context):base(context)
        {

        }

        public override IQueryable<Avaliacao> BuscarTodos()
        {
            return _context.Avaliacao.AsQueryable();
        }

        public override Avaliacao Buscar(Guid id)
        {
            return _context.Avaliacao.FirstOrDefault(e => e.Id == id);
        }

        public override void Inserir(Avaliacao entity)
        {
            _context.Avaliacao.Add(entity);
        }

        public override void Deletar(Avaliacao entity)
        {
            _context.Avaliacao.Remove(entity);
        }
    }
}
