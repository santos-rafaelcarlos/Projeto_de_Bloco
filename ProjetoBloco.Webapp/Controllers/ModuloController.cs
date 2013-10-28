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
    public class ModuloController : Controller
    {
        private IRepositorio<Modulo> Repositorio { get; set; }
        private IRepositorio<Professor> ProfessorRepositorio { get; set; }
        private IRepositorio<Curso> CursosRepositorio { get; set; }
        public ModuloController(IRepositorio<Modulo> _repositorio, IRepositorio<Professor> _professorRepositorio, IRepositorio<Curso> _cursoRepositorio)
        {
            Repositorio = _repositorio;
            ProfessorRepositorio = _professorRepositorio;
            CursosRepositorio = _cursoRepositorio;
        }

        //
        // GET: /Modulo/

        public ActionResult Index()
        {           
            return View(Repositorio.BuscarTodos().AsEnumerable());
        }

        //
        // GET: /Modulo/Details/5

        public ActionResult Details(Guid id = default(Guid))
        {
            Modulo modulo = Repositorio.Buscar(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        //
        // GET: /Modulo/Create

        public ActionResult Create()
        {
            ViewBag.ProfessorID = new SelectList(TodosProfessoresEnumerable(), "Id", "Nome");
            ViewBag.CursoID = new SelectList(TodosCursosEnumerable(), "Id", "Nome");
            return View();
        }

        //
        // POST: /Modulo/Create

        [HttpPost]
        public ActionResult Create(Modulo modulo)
        {  
            if (ModelState.IsValid)
            {
                Repositorio.Incluir(modulo);
                return RedirectToAction("Index");
            }

            ViewBag.ProfessorID = new SelectList(TodosProfessoresEnumerable(), "Id", "Nome", modulo.ProfessorID);
            ViewBag.CursoID = new SelectList(TodosCursosEnumerable(), "Id", "Nome", modulo.CursoID);
            return View(modulo);
        }

        //
        // GET: /Modulo/Edit/5

        public ActionResult Edit(Guid id = default(Guid))
        {
            Modulo modulo = Repositorio.Buscar(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfessorID = new SelectList(TodosProfessoresEnumerable(), "Id", "Nome", modulo.ProfessorID);
            ViewBag.CursoID = new SelectList(TodosCursosEnumerable(), "Id", "Nome", modulo.CursoID);
            return View(modulo);
            
        }

        //
        // POST: /Modulo/Edit/5

        [HttpPost]
        public ActionResult Edit(Modulo modulo)
        {
            ModelState["Professor"].Errors.Clear();
            ModelState["Curso"].Errors.Clear();

            if (ModelState.IsValid)
            {
                Repositorio.Atualizar(modulo);
                return RedirectToAction("Index");
            }
            ViewBag.ProfessorID = new SelectList(TodosProfessoresEnumerable(), "Id", "Nome", modulo.ProfessorID);
            ViewBag.CursoID = new SelectList(TodosCursosEnumerable(), "Id", "Nome", modulo.CursoID);
            return View(modulo);
        }

        //
        // GET: /Modulo/Delete/5

        public ActionResult Delete(Guid id = default(Guid))
        {
            Modulo modulo = Repositorio.Buscar(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        //
        // POST: /Modulo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Modulo modulo = Repositorio.Buscar(id);
            Repositorio.Excluir(modulo);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
        }

        private IEnumerable<Professor> TodosProfessoresEnumerable()
        {
            return ProfessorRepositorio.BuscarTodos().AsEnumerable();
        }

        private IEnumerable<Curso> TodosCursosEnumerable()
        {
            return CursosRepositorio.BuscarTodos().AsEnumerable();
        }
    }
}