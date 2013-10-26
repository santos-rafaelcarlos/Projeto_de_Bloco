using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.DaoEF;
using ProjetoBloco.Modelo;

namespace ProjetoBloco.DAO
{
    public class ModuloDAO : DaoGenerico<Modulo>
    {
        public ModuloDAO(ProjetoContext context)
            : base(context)
        {

        }


        public override IQueryable<Modulo> BuscarTodos()
        {
            return _context.Modulo.AsQueryable();
        }

        public override Modulo Buscar(Guid id)
        {
            return _context.Modulo.FirstOrDefault(e => e.Id == id);
        }

        public override void Inserir(Modulo entity)
        {
            _context.Modulo.Add(entity);
        }

        public override void Deletar(Modulo entity)
        {
            _context.Modulo.Remove(entity);
        }
    }
}
