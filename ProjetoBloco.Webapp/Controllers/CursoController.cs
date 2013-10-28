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
    public class CursoController : Controller
    {
        private IRepositorio<Curso> Repositorio { get; set; }
        public CursoController(IRepositorio<Curso> _repositorio)
        {
            Repositorio = _repositorio;
        }

        //
        // GET: /Curso/

        public ActionResult Index()
        {
            return View(Repositorio.BuscarTodos().AsEnumerable());
        }

        //
        // GET: /Curso/Details/5

        public ActionResult Details(Guid id = default(Guid))
        {
            Curso curso = Repositorio.Buscar(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        //
        // GET: /Curso/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Curso/Create

        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Incluir(curso);
                return RedirectToAction("Index");
            }

            return View(curso);
        }

        //
        // GET: /Curso/Edit/5

        public ActionResult Edit(Guid id = default(Guid))
        {
            Curso curso = Repositorio.Buscar(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        //
        // POST: /Curso/Edit/5

        [HttpPost]
        public ActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Atualizar(curso);
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        //
        // GET: /Curso/Delete/5

        public ActionResult Delete(Guid id = default(Guid))
        {
            Curso curso = Repositorio.Buscar(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        //
        // POST: /Curso/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Curso curso = Repositorio.Buscar(id);
            Repositorio.Excluir(curso);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
        }
    }
}