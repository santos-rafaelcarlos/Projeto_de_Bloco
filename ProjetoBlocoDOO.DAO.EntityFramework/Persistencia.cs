using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.DaoEF;
using ProjetoBloco.Modelo;

namespace ProjetoBlocoDOO.DaoEF
{
    public sealed class Persistencia<T> where T: class,IIdentificavel
    {
        private static Dictionary<Type, Persistencia<T>> _instances = new Dictionary<Type, Persistencia<T>>();

        private static ProjetoContext _context = null;
        private DaoGenerico<T> _Dao = null;

        Persistencia()
        {
            if (_context == null)
            {
                string connString = @"Server=SANTOS_RCS-NOTE\LOCAL;Database=Projeto;Trusted_Connection=true;";
                _context = new ProjetoContext(connString);

                _context.Configuration.LazyLoadingEnabled = true;
                _context.Configuration.ProxyCreationEnabled = true;
            }

            _Dao = new DaoGenerico<T>(_context);
        }

        public static Persistencia<T> Instance
        {
            get
            {
                if (!_instances.ContainsKey(typeof(T)))
                    _instances.Add(typeof(T), new Persistencia<T>());

                return _instances[typeof(T)];
            }
        }

        public DaoGenerico<T> DAOGenerico { get { return _Dao; } }
    }
}
