using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.DaoEF;
using ProjetoBloco.Modelo;
using ProjetoBloco.DAO;

namespace ProjetoBloco.DaoEF
{
    public sealed class Persistencia<T> where T: class,IIdentificavel
    {
        private static Dictionary<Type, Persistencia<T>> _instances = new Dictionary<Type, Persistencia<T>>();

        private static ProjetoContext _context = null;
        private IDAL<T> _Dao = null;

        Persistencia()
        {
            if (_context == null)
            {
                string connString = @"Server=.\sqlexpress;Database=ProjetoBlocoV3;Trusted_Connection=true;";
                _context = new ProjetoContext(connString);
                               
                _context.Configuration.LazyLoadingEnabled = true;
                _context.Configuration.ProxyCreationEnabled = true;
            }

            switch (typeof(T).Name)
            {
                case "Administrador":
                    _Dao = (IDAL<T>)new AdministradorDAO(_context);
                    break;
                case "Aluno":
                    _Dao = (IDAL<T>)new AlunoDAO(_context);
                    break;
                case "Avaliacao":
                    _Dao = (IDAL<T>)new AvaliacaoDAO(_context);
                    break;
                case "Curso":
                    _Dao = (IDAL<T>)new CursoDAO(_context);
                    break;
                case "Modulo":
                    _Dao = (IDAL<T>)new ModuloDAO(_context);
                    break;
                case "Professor":
                    _Dao = (IDAL<T>)new ProfessorDAO(_context);
                    break;
                case "Questionario":
                    _Dao = (IDAL<T>)new QuestionarioDAO(_context);
                    break;
                case "Resposta":
                    _Dao = (IDAL<T>)new RespostaDAO(_context);
                    break;
                case "Questao":
                default:                
                    _Dao = (IDAL<T>)new QuestaoDAO(_context);                    
                    break;
            }
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

        public IDAL<T> DAOGenerico { get { return _Dao; } }
    }
}
