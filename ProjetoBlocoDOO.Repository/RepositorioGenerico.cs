using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.Repository
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T : class,IIdentificavel
    {
        public IQueryable<T> BuscarTodos()
        {
            return Persistencia<T>.Instance.DAOGenerico.BuscarTodos();
        }

        public void Incluir(T entidade)
        {
            Persistencia<T>.Instance.DAOGenerico.Inserir(entidade);
        }


        public void Atualizar(T entidade)
        {
            Persistencia<T>.Instance.DAOGenerico.Atualizar(entidade);
        }

        public void Excluir(T entidade)
        {
            Persistencia<T>.Instance.DAOGenerico.Deletar(entidade);
        }

        public T Buscar(Guid id)
        {
            return Persistencia<T>.Instance.DAOGenerico.Buscar(id);
        }
    }
}
