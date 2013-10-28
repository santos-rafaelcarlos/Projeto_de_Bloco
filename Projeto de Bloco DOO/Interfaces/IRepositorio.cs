using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBloco.Modelo
{
    public interface IRepositorio<T> where T : class,IIdentificavel
    {
        IQueryable<T> BuscarTodos();

        void Incluir(T entidade);

        void Atualizar(T entidade);

        void Excluir(T entidade);

        T Buscar(Guid id);
    }
}
