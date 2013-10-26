using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.Repository
{
    public class RepositorioGenerico<T> where T : class,IIdentificavel
    {
        public static IQueryable<T> BuscarTodos()
        {
            return Persistencia<T>.Instance.DAOGenerico.BuscarTodos();
        }

        public static void Salvar(T entidade)
        {
            Persistencia<T>.Instance.DAOGenerico.Inserir(entidade);
        }

        public static void Excluir(T entidade)
        {
            Persistencia<T>.Instance.DAOGenerico.Deletar(entidade);
        }

        public static T Buscar(Guid id)
        {
            return Persistencia<T>.Instance.DAOGenerico.Buscar(id);
        }
    }
}
