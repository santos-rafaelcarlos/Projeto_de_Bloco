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
        
        public List<T> BuscarTodos()
        {
            return _context.Set<T>().ToList();
        }

        public T Buscar(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void Inserir(T entity)
        {
            _context.Set<T>().Add(entity);
            SalvarTudo();
        }

        public void Deletar(T entity)
        {
            _context.Set<T>().Remove(entity);
            SalvarTudo();
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
