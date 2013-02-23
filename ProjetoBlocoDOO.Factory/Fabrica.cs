using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBloco.Modelo;
using System.Reflection;

namespace ProjetoBloco.Factory
{
    public class Fabrica
    {
        #region private
        private static Dictionary<string, object> props = null;

        private static void PreencherPessoaProps(string nome, string email)
        {
            props.Add("Nome", nome);
            props.Add("Email", email);
        }

        private static void PreencherUsuarioProps(string login, string senha)
        {
            props.Add("Login", login);
            props.Add("Senha", senha);
        }
        #endregion

        public static Administrador Criar(string nome, string email, string login, string senha)
        {
            props = new Dictionary<string, object>();
            PreencherPessoaProps(nome, email);
            PreencherUsuarioProps(login, senha);

            return GerenciadorFabrica<Administrador>.Instance.CriarInstancia(props);
        }


        public static Aluno Criar(Int32 matricula, string nome, string email, string login, string senha)
        {
            props = new Dictionary<string,object>();
            PreencherPessoaProps(nome,email);
            PreencherUsuarioProps(login,senha);
            props.Add("Matricula",matricula);
                        
            return GerenciadorFabrica<Aluno>.Instance.CriarInstancia(props);
        }

        public static Avaliacao Criar(Aluno aluno,string comentarios,DateTime inicio, DateTime? fim,Modulo modulo,Questionario questionario)        
        {
            props = new Dictionary<string, object>();
            props.Add("Aluno", aluno);
            props.Add("Comentarios", comentarios);
            props.Add("DataInicio", inicio);
            props.Add("DataTermino", fim);
            props.Add("Modulo", modulo);
            props.Add("Questionario",questionario);

            return GerenciadorFabrica<Avaliacao>.Instance.CriarInstancia(props);
        }

        public static Curso Criar(string nome)
        {
            props = new Dictionary<string, object>();
            props.Add("Nome", nome);

            return GerenciadorFabrica<Curso>.Instance.CriarInstancia(props);
        }

        public static Modulo Criar(string nome, Professor professor, Curso curso, List<Aluno> alunos)
        {
            props = new Dictionary<string, object>();
            props.Add("Nome", nome);
            props.Add("Professor", professor);
            props.Add("Curso", curso);
            props.Add("Alunos", alunos);

            return  GerenciadorFabrica<Modulo>.Instance.CriarInstancia(props);
        }

        public static Professor Criar(Int32 matricula, string nome, string email)
        {
            props = new Dictionary<string, object>();
            PreencherPessoaProps(nome, email);
            props.Add("Matricula", matricula);
            
            return GerenciadorFabrica<Professor>.Instance.CriarInstancia(props);
        }

        private static Questao CriarQuestao(string texto)
        {
            props = new Dictionary<string, object>();
            props.Add("Texto", texto);

            return GerenciadorFabrica<Questao>.Instance.CriarInstancia(props);
        }

        public static Questionario Criar(Administrador adm, List<string> questoes)
        {            
            List<Questao> lista = new List<Questao>();
            foreach (var texto in questoes)
                lista.Add(CriarQuestao(texto));

            props = new Dictionary<string, object>();
            props.Add("Criador" ,adm);
            props.Add("Questoes", lista);

            Questionario item = GerenciadorFabrica<Questionario>.Instance.CriarInstancia(props);

            foreach (var questao in item.Questoes)
                questao.Questionario = item;

            return item;
        }
    }

    internal class Fabrica<T> where T : IIdentificavel
    {
        protected T CriarItem(string nomeContrutor,object[] parametros)
        {
            T item = (T)typeof(T).InvokeMember(nomeContrutor, BindingFlags.CreateInstance, default(Binder), null, parametros);
            item.Id = Guid.NewGuid();

            return item;
        }

        protected void PopularPropriedades(T item, Dictionary<string, object> propriedades)
        {
            foreach (var propriedade in propriedades)
            {
                PropertyInfo pi = item.GetType().GetProperty(propriedade.Key);
                pi.SetValue(item, propriedade.Value, null);
            }            
        }

        internal T CriarInstancia(Dictionary<string, object> propriedades) 
        {
            T item = CriarItem(string.Empty, new object[] { });
            PopularPropriedades(item, propriedades);

            return item;
        }
    }

    internal sealed class GerenciadorFabrica<T> where T : IIdentificavel
    {
        private static Dictionary<Type, Fabrica<T>> _instances = new Dictionary<Type, Fabrica<T>>();

        internal static Fabrica<T> Instance
        {
            get
            {
                if (!_instances.ContainsKey(typeof(T)))
                    _instances.Add(typeof(T), new Fabrica<T>());

                return _instances[typeof(T)];
            }
        }

    }
}
