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
    public class ProfessorController : Controller
    {
        private IRepositorio<Professor> Repositorio { get; set; }
        public ProfessorController(IRepositorio<Professor> _repositorio)
        {
            Repositorio = _repositorio;

        }

        //
        // GET: /Professor/

        public ActionResult Index()
        {
            return View(Repositorio.BuscarTodos().AsEnumerable());
        }

        //
        // GET: /Professor/Details/5

        public ActionResult Details(Guid id = default(Guid))
        {
            Professor professor = Repositorio.Buscar(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        //
        // GET: /Professor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Professor/Create

        [HttpPost]
        public ActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Incluir(professor);
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        //
        // GET: /Professor/Edit/5

        public ActionResult Edit(Guid id = default(Guid))
        {
            Professor professor = Repositorio.Buscar(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        //
        // POST: /Professor/Edit/5

        [HttpPost]
        public ActionResult Edit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Atualizar(professor);
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        //
        // GET: /Professor/Delete/5

        public ActionResult Delete(Guid id = default(Guid))
        {
            Professor professor = Repositorio.Buscar(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        //
        // POST: /Professor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Professor professor = Repositorio.Buscar(id);
            Repositorio.Excluir(professor);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
        }
    }
}