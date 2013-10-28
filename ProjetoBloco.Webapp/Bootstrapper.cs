using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using ProjetoBloco.Modelo;
using ProjetoBloco.Repository;

namespace ProjetoBloco.Webapp
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<IRepositorio<Administrador>,RepositorioGenerico<Administrador>>(new ContainerControlledLifetimeManager());
        container.RegisterType<IRepositorio<Aluno>,RepositorioGenerico<Aluno>>(new ContainerControlledLifetimeManager());
        container.RegisterType<IRepositorio<Avaliacao>,RepositorioGenerico<Avaliacao>>(new ContainerControlledLifetimeManager());
        container.RegisterType<IRepositorio<Curso>,RepositorioGenerico<Curso>>(new ContainerControlledLifetimeManager());
        container.RegisterType<IRepositorio<Modulo>,RepositorioGenerico<Modulo>>(new ContainerControlledLifetimeManager());
        container.RegisterType<IRepositorio<Professor>,RepositorioGenerico<Professor>>(new ContainerControlledLifetimeManager());
        container.RegisterType<IRepositorio<Questao>,RepositorioGenerico<Questao>>(new ContainerControlledLifetimeManager());
        container.RegisterType<IRepositorio<Questionario>,RepositorioGenerico<Questionario>>(new ContainerControlledLifetimeManager());
        container.RegisterType<IRepositorio<Resposta>, RepositorioGenerico<Resposta>>(new ContainerControlledLifetimeManager());

    }
  }
}