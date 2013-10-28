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
    public class AvaliacaoController : Controller
    {
        private IRepositorio<Avaliacao> Repositorio { get; set; }
        private IRepositorio<Modulo> ModuloRepositorio { get;set;}
        private IRepositorio<Aluno> AlunoRepositorio { get; set; }
        private IRepositorio<Questionario> QuestionarioRepositorio { get;set;}
        private IRepositorio<Administrador> AdmRepositorio { get; set; }

        public AvaliacaoController(IRepositorio<Avaliacao> _repositorio,
            IRepositorio<Aluno> _pessoaRepositorio,
            IRepositorio<Questionario> _questionarioRepositorio,
            IRepositorio<Modulo> _moduloRepositorio,IRepositorio<Administrador> _admRepositorio)
        {
            Repositorio = _repositorio;
            AlunoRepositorio = _pessoaRepositorio;
            QuestionarioRepositorio = _questionarioRepositorio;
            ModuloRepositorio = _moduloRepositorio;
            AdmRepositorio = _admRepositorio;
        }

        //
        // GET: /Avaliacao/

        public ActionResult Index()
        {         
           
            return View(Repositorio.BuscarTodos().AsEnumerable());
        }

        //
        // GET: /Avaliacao/Details/5

        public ActionResult Details(Guid id = default(Guid))
        {
            Avaliacao avaliacao = Repositorio.Buscar(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        //
        // GET: /Avaliacao/Create

        public ActionResult Create()
        {
            ViewBag.AlunoID = new SelectList(TodosPessoaEnumerable(), "Id", "Nome");
            ViewBag.QuestionarioID = new SelectList(TodosQuestionariosEnumerable(), "Id", "Identificador");
            ViewBag.ModuloID = new SelectList(TodosModulosEnumerable(), "Id", "Nome");
            return View();
        }

        //
        // POST: /Avaliacao/Create

        [HttpPost]
        public ActionResult Create(Avaliacao avaliacao)
        {          
            if (ModelState.IsValid)
            {
                Administrador adm = AdmRepositorio.BuscarTodos()
                 .Where(a => string.Compare(a.Login, User.Identity.Name, true) == 0).FirstOrDefault();
                avaliacao.CriadorID = adm.Id;

                Repositorio.Incluir(avaliacao);
                return RedirectToAction("Index");
            }

            ViewBag.AlunoID = new SelectList(TodosPessoaEnumerable(), "Id", "Nome", avaliacao.AlunoID);
            ViewBag.QuestionarioID = new SelectList(TodosQuestionariosEnumerable(), "Id", "Identificador", avaliacao.QuestionarioID);
            ViewBag.ModuloID = new SelectList(TodosModulosEnumerable(), "Id", "Nome", avaliacao.ModuloID);
            return View(avaliacao);
        }

        //
        // GET: /Avaliacao/Edit/5

        public ActionResult Edit(Guid id = default(Guid))
        {
            Avaliacao avaliacao = Repositorio.Buscar(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoID = new SelectList(TodosPessoaEnumerable(), "Id", "Nome", avaliacao.AlunoID);
            ViewBag.QuestionarioID = new SelectList(TodosQuestionariosEnumerable(), "Id", "Identificador", avaliacao.QuestionarioID);
            ViewBag.ModuloID = new SelectList(TodosModulosEnumerable(), "Id", "Nome", avaliacao.ModuloID);
            return View(avaliacao);
        }

        //
        // POST: /Avaliacao/Edit/5

        [HttpPost]
        public ActionResult Edit(Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                Repositorio.Atualizar(avaliacao);
                return RedirectToAction("Index");
            }
            ViewBag.AlunoID = new SelectList(TodosPessoaEnumerable(), "Id", "Nome", avaliacao.AlunoID);
            ViewBag.QuestionarioID = new SelectList(TodosQuestionariosEnumerable(), "Id", "Identificador", avaliacao.QuestionarioID);
            ViewBag.ModuloID = new SelectList(TodosModulosEnumerable(), "Id", "Nome", avaliacao.ModuloID);
            return View(avaliacao);
        }

        //
        // GET: /Avaliacao/Delete/5

        public ActionResult Delete(Guid id = default(Guid))
        {
            Avaliacao avaliacao = Repositorio.Buscar(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        //
        // POST: /Avaliacao/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Avaliacao avaliacao = Repositorio.Buscar(id);
            Repositorio.Excluir(avaliacao);
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
        
        private IEnumerable<Aluno> TodosPessoaEnumerable()
        {
            return AlunoRepositorio.BuscarTodos().AsEnumerable();
        }
        private IEnumerable<Questionario> TodosQuestionariosEnumerable()
        {
            return QuestionarioRepositorio.BuscarTodos().AsEnumerable();
        }
    }
}