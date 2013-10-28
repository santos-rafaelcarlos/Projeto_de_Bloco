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
    [Authorize(Roles = "admin, superUser")]
    public class AdministradorController : Controller
    {
        private IRepositorio<Administrador> Repositorio { get; set; }
        public AdministradorController(IRepositorio<Administrador> _repositorio)
        {
            Repositorio = _repositorio;
        }

        //
        // GET: /Administrador/

        public ActionResult Index()
        {
            return View(Repositorio.BuscarTodos().AsEnumerable());
        }

        //
        // GET: /Administrador/Details/5

        public ActionResult Details(Guid id = default(Guid))
        {
            Administrador administrador = Repositorio.Buscar(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        //
        // GET: /Administrador/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrador/Create

        [HttpPost]
        public ActionResult Create(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Incluir(administrador);

                MembershipUser user = Membership.CreateUser(administrador.Login,
                    Membership.GeneratePassword(6, 1),
                    administrador.Email);
                
                if (user.IsApproved)
                {
                    Roles.AddUsersToRole(new string[] { administrador.Login },"admin");

                    SGAccountController accountController = new SGAccountController();
                    accountController.ForgotPassword(
                        new SecurityGuard.ViewModels.ForgotPasswordViewModel()
                        {
                            RequireSecretQuestionAndAnswer = false,
                            Email = administrador.Email,
                            Checked = false,
                        });
                }

                return RedirectToAction("Index");
            }

            return View(administrador);
        }

        //
        // GET: /Administrador/Edit/5

        public ActionResult Edit(Guid id = default(Guid))
        {
            Administrador administrador = Repositorio.Buscar(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        //
        // POST: /Administrador/Edit/5

        [HttpPost]
        public ActionResult Edit(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Atualizar(administrador);
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        //
        // GET: /Administrador/Delete/5

        public ActionResult Delete(Guid id = default(Guid))
        {
            Administrador administrador = Repositorio.Buscar(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        //
        // POST: /Administrador/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Administrador administrador = Repositorio.Buscar(id);
            Membership.DeleteUser(administrador.Login); 

            Repositorio.Excluir(administrador);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
        }
    }
}