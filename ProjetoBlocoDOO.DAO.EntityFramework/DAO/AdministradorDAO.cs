using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.DAO
{
    public class AdministradorDAO : DaoGenerico<Administrador>
    {
        public AdministradorDAO(ProjetoContext context):base(context)
        {

        }

        public override IQueryable<Administrador> BuscarTodos()
        {
            return _context.Administrador.AsQueryable();
        }

        public override Administrador Buscar(Guid id)
        {
            return _context.Administrador.FirstOrDefault(e => e.Id == id);
        }

        public override void Inserir(Administrador entity)
        {
            _context.Administrador.Add(entity);
            SalvarTudo();
        }

        public override void Deletar(Administrador entity)
        {
            _context.Administrador.Remove(entity);
            SalvarTudo();
        }
    }
}
