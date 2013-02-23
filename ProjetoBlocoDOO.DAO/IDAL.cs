using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBloco.DAO
{
    public interface IDAL<T>
    {
        List<T> BuscarTodos();

        T Buscar(Guid id);

        void Inserir(T entity);
        void Deletar(T entity);
        void Atualizar(T entity);
        void SalvarTudo();
    }
}