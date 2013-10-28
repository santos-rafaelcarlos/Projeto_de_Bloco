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
            Questionario quest =_context.Questionario.Find(id);
            quest.Criador = _context.Administrador.Find(quest.CriadorID);
            quest.Questoes = _context.Questao.Where(q => q.QuestionarioID == id).ToList();

            return quest;
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
