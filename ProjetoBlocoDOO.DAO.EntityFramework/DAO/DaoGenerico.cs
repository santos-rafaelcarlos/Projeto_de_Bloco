using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBlocoDOO.DAO;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBlocoDOO.DaoEF
{
    public class DaoGenerico<T> : IDAL<T> where T : class,IIdentificavel
    {
        private readonly ProjetoContext _context = null;

        public DaoGenerico(ProjetoContext context)
        {
            _context = context;
        }
        
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(Guid id)
        {            
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            SaveAll();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            SaveAll();
        }

        public void Update(T entity)
        {
            SaveAll();
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }
    }
}
