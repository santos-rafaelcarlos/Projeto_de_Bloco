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
            Resposta resp = _context.Resposta.Find(id);
            resp.Avaliacao = _context.Avaliacao.Find(resp.AvaliacaoID);
            resp.Questao = _context.Questao.Find(resp.QuestaoID);
            return resp;
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
