using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.DAO
{
    public class RespostaDAO : DaoGenerico<Resposta>
    {
        public RespostaDAO(ProjetoContext context)
            : base(context)
        {

        }

        public override IQueryable<Resposta> BuscarTodos()
        {
            return _context.Resposta.AsQueryable();
        }

        public override Resposta Buscar(Guid id)
        {
            return _context.Resposta.FirstOrDefault(e => e.Id == id);
        }

        public override void Inserir(Resposta entity)
        {
            _context.Resposta.Add(entity);
            SalvarTudo();
        }

        public override void Deletar(Resposta entity)
        {
            _context.Resposta.Remove(entity);
            SalvarTudo();
        }

    }
}
