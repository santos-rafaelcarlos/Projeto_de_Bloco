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
    public class QuestaoController : Controller
    {
        public IRepositorio<Questao> Repositorio { get; set; }
        public IRepositorio<Questionario> QuestionarioRepositorio { get; set; }
        public QuestaoController(IRepositorio<Questao> _repositorio,IRepositorio<Questionario> _questionarioRepositorio)
        {
            Repositorio = _repositorio;
            QuestionarioRepositorio = _questionarioRepositorio;
        }

        //
        // GET: /Questao/

        public ActionResult Index()
        {            
            return View(Repositorio.BuscarTodos().AsEnumerable());
        }

        //
        // GET: /Questao/Details/5

        public ActionResult Details(Guid id = default(Guid))
        {
            Questao questao = Repositorio.Buscar(id);
            if (questao == null)
            {
                return HttpNotFound();
            }
            return View(questao);
        }

        //
        // GET: /Questao/Create

        public ActionResult Create()
        {
            ViewBag.QuestionarioID = new SelectList(TodosQuestionariosEnumerable(), "Id", "Identificador");
            return View();
        }

        //
        // POST: /Questao/Create

        [HttpPost]
        public ActionResult Create(Questao questao)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Incluir(questao);
                return RedirectToAction("Index");
            }

            ViewBag.QuestionarioID = new SelectList(TodosQuestionariosEnumerable(), "Id", "Identificador", questao.QuestionarioID);
            return View(questao);
        }

        //
        // GET: /Questao/Edit/5

        public ActionResult Edit(Guid id = default(Guid))
        {
            Questao questao = Repositorio.Buscar(id);
            if (questao == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionarioID = new SelectList(TodosQuestionariosEnumerable(), "Id", "Identificador", questao.QuestionarioID);
            return View(questao);
        }

        //
        // POST: /Questao/Edit/5

        [HttpPost]
        public ActionResult Edit(Questao questao)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Atualizar(questao);
                return RedirectToAction("Index");
            }
            ViewBag.QuestionarioID = new SelectList(TodosQuestionariosEnumerable(), "Id", "Identificador", questao.QuestionarioID);
            return View(questao);
        }

        //
        // GET: /Questao/Delete/5

        public ActionResult Delete(Guid id = default(Guid))
        {
            Questao questao = Repositorio.Buscar(id);
            if (questao == null)
            {
                return HttpNotFound();
            }
            return View(questao);
        }

        //
        // POST: /Questao/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Questao questao = Repositorio.Buscar(id);
            Repositorio.Excluir(questao);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
        }

        private IEnumerable<Questionario> TodosQuestionariosEnumerable()
        {
            return QuestionarioRepositorio.BuscarTodos().AsEnumerable();
        }
    }
}