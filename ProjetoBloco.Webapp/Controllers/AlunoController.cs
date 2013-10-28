using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;
using System.Web.Security;

namespace ProjetoBloco.Webapp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AlunoController : Controller
    {
        private IRepositorio<Aluno> Repositorio { get; set; }
        private IRepositorio<Modulo> ModuloRepositorio { get; set; }
        public AlunoController(IRepositorio<Aluno> _repositorio,IRepositorio<Modulo> _moduloRepositorio)
        {
            Repositorio = _repositorio;
            ModuloRepositorio = _moduloRepositorio;
        }

        //
        // GET: /Aluno/

        public ActionResult Index()
        {            
            return View(Repositorio.BuscarTodos().AsEnumerable());
        }

        //
        // GET: /Aluno/Details/5

        public ActionResult Details(Guid id = default(Guid))
        {
            Aluno aluno = Repositorio.Buscar(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        //
        // GET: /Aluno/Create

        public ActionResult Create()
        {
            ViewBag.ModuloID = new SelectList(TodosModulosEnumerable(), "Id", "Nome");
            return View();
        }

        //
        // POST: /Aluno/Create

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                MembershipUser user = Membership.CreateUser(aluno.Login,
                    Membership.GeneratePassword(6, 0),
                    aluno.Email);
                                
                 if (user.IsApproved)
                 {
                     Repositorio.Incluir(aluno);

                     Roles.AddUsersToRole(new string[] { aluno.Login }, "aluno");


                     SGAccountController accountController = new SGAccountController();
                     accountController.ForgotPassword(
                         new SecurityGuard.ViewModels.ForgotPasswordViewModel()
                         {
                             RequireSecretQuestionAndAnswer = false,
                             Email = aluno.Email,
                             Checked = false,
                         });
                 }

                return RedirectToAction("Index");
            }

            ViewBag.ModuloID = new SelectList(TodosModulosEnumerable(), "Id", "Nome", aluno.ModuloID);
            return View(aluno);
        }

        //
        // GET: /Aluno/Edit/5

        public ActionResult Edit(Guid id = default(Guid))
        {
            Aluno aluno = Repositorio.Buscar(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuloID = new SelectList(TodosModulosEnumerable(), "Id", "Nome", aluno.ModuloID);
            return View(aluno);
        }

        //
        // POST: /Aluno/Edit/5

        [HttpPost]
        public ActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Atualizar(aluno);
               
                return RedirectToAction("Index","Home");
            }
            ViewBag.ModuloID = new SelectList(TodosModulosEnumerable(), "Id", "Nome", aluno.ModuloID);
            return View(aluno);
        }

        //
        // GET: /Aluno/Delete/5

        public ActionResult Delete(Guid id = default(Guid))
        {
            Aluno aluno = Repositorio.Buscar(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        //
        // POST: /Aluno/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Aluno aluno = Repositorio.Buscar(id);
            Membership.DeleteUser(aluno.Login);
            Repositorio.Excluir(aluno);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
        }

        private IEnumerable<Modulo> TodosModulosEnumerable()
        {
            return ModuloRepositorio.BuscarTodos().AsEnumerable();
        }
    }
}