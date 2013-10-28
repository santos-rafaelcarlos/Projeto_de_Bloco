using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBloco.Modelo;
using ProjetoBloco.DaoEF;

namespace ProjetoBloco.Webapp.Controllers
{
     [Authorize(Roles = "admin")]
    public class QuestionarioController : Controller
    {
        private IRepositorio<Questionario> Repositorio { get; set; }
        private IRepositorio<Administrador> AdmRepositorio { get; set; }
        public QuestionarioController(IRepositorio<Questionario> _repositorio,
            IRepositorio<Administrador> _admRepositorio)
        {
            Repositorio = _repositorio;
            AdmRepositorio = _admRepositorio;
        }

        //
        // GET: /Questionario/

        public ActionResult Index()
        {

          var adm =  (from a in AdmRepositorio.BuscarTodos()
                      where a.Login == User.Identity.Name                      
                      select a.Id).FirstOrDefault();

            var questionarios = Repositorio.BuscarTodos()
                .Where(q=>q.CriadorID == adm).ToArray();
            
            return View(questionarios);
        }

        //
        // GET: /Questionario/Details/5

        public ActionResult Details(Guid id = default(Guid))
        {
            Questionario questionario = Repositorio.Buscar(id);
            if (questionario == null)
            {
                return HttpNotFound();
            }
            return View(questionario);
        }

        //
        // GET: /Questionario/Create

        public ActionResult Create()
        {
            //ViewBag.CriadorID = new SelectList(db.Pessoa, "Id", "Nome");
            return View();
        }

        //
        // POST: /Questionario/Create

        [HttpPost]
        public ActionResult Create(Questionario questionario)
        {
            if (ModelState.IsValid)
            {
                Administrador adm = AdmRepositorio.BuscarTodos()
                    .Where(a => string.Compare(a.Login, User.Identity.Name, true) == 0).FirstOrDefault();
                questionario.CriadorID = adm.Id;

                Repositorio.Incluir(questionario);
                return RedirectToAction("Index");
            }
                        
            return View(questionario);
        }

        //
        // GET: /Questionario/Edit/5

        public ActionResult Edit(Guid id = default(Guid))
        {
            Questionario questionario = Repositorio.Buscar(id);
            if (questionario == null)
            {
                return HttpNotFound();
            }
            
            return View(questionario);
        }

        //
        // POST: /Questionario/Edit/5

        [HttpPost]
        public ActionResult Edit(Questionario questionario)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Atualizar(questionario);
                return RedirectToAction("Index");
            }
            
            return View(questionario);
        }

        //
        // GET: /Questionario/Delete/5

        public ActionResult Delete(Guid id = default(Guid))
        {
            Questionario questionario = Repositorio.Buscar(id);
            if (questionario == null)
            {
                return HttpNotFound();
            }
            return View(questionario);
        }

        //
        // POST: /Questionario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Questionario questionario = Repositorio.Buscar(id);
            Repositorio.Excluir(questionario);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
        }

      
    }
}