using System.Data.Entity;
using ProjetoBloco.Modelo;
using System.Data.Entity.ModelConfiguration.Conventions;

///Após Criar o banco de dados é necessário alterar o campo "QuestionarioID" na 
///tabela "Questao" para aceitar valores nulos
namespace ProjetoBloco.DaoEF
{    
    public class ProjetoContext : DbContext
    {
        public ProjetoContext():base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Questao>()
                .HasRequired(q => q.Questionario)
                .WithMany(q => q.Questoes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aluno>()
                .HasRequired(a => a.Modulo)
                .WithMany(m => m.Alunos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resposta>()
                .HasRequired(r => r.Avaliacao)
                .WithMany(a => a.Respostas)
                .WillCascadeOnDelete(true);
        }

        public ProjetoContext(string connectionString)
            : base(connectionString)
        {
            
        }
       
        public DbSet<Questao> Questao { get; set; }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Administrador> Administrador { get; set; }

        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Questionario> Questionario { get; set; }        
        public DbSet<IPessoa> Pessoa { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Professor> Professor { get; set; }

        public DbSet<Resposta> Resposta { get; set; }
    }
}
