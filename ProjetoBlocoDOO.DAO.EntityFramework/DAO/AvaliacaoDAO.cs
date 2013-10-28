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
            Avaliacao item =_context.Avaliacao.Find(id);
            item.Modulo = _context.Modulo.Find(item.ModuloID);
            item.Questionario = _context.Questionario.Find(item.QuestionarioID);
            item.Criador = _context.Administrador.Find(item.CriadorID);

            return item;
        }

        public override void Inserir(Avaliacao entity)
        {
            _context.Avaliacao.Add(entity);
            SalvarTudo();
        }

        public override void Deletar(Avaliacao entity)
        {
            _context.Avaliacao.Remove(entity);
            SalvarTudo();
        }
    }
}
