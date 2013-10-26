using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.DAO
{
    public class AlunoDAO : DaoGenerico<Aluno>
    {
        public AlunoDAO(ProjetoContext context):base(context)
        {

        }

        public override IQueryable<Aluno> BuscarTodos()
        {
            return _context.Aluno.AsQueryable();
        }

        public override Aluno Buscar(Guid id)
        {
            return _context.Aluno.FirstOrDefault(e => e.Id == id);
        }

        public override void Inserir(Aluno entity)
        {
            _context.Aluno.Add(entity);
        }

        public override void Deletar(Aluno entity)
        {
            _context.Aluno.Remove(entity);
        }
    }
}
