using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBlocoDOO.DaoEF;

namespace ProjetoBlocoDOO.Repository
{
    public class RepositorioGenerico<T> where T : class,IIdentificavel
    {
        public List<T> BuscarTodos()
        {
            return Persistencia<T>.Instance.DAOGenerico.BuscarTodos();
        }
        
        public void Salvar(T entidade)
        {
            Persistencia<T>.Instance.DAOGenerico.Inserir(entidade);
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
