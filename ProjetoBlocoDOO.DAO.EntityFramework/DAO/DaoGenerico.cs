using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.DAO;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.DaoEF
{
    public abstract class DaoGenerico<T> : IDAL<T> where T : class,IIdentificavel
    {
        protected readonly ProjetoContext _context = null;

        public DaoGenerico(ProjetoContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> BuscarTodos() 
        {
         return _context.Set<T>().AsQueryable();
        }

        public virtual T Buscar(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public virtual void Inserir(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Deletar(T entity) 
        {
            _context.Set<T>().Remove(entity);
        }
            
        public void Atualizar(T entity)
        {
            SalvarTudo();
        }

        public void SalvarTudo()
        {
            _context.SaveChanges();
        }
    }
}
