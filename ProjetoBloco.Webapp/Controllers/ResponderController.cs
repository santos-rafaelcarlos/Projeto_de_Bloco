using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBloco.Modelo;
using ProjetoBloco.Webapp.Models;

namespace ProjetoBloco.Webapp.Controllers
{
    [Authorize(Roles = "aluno")]
    public class ResponderController : Controller
    {
        //
        // GET: /Responder/
        private IRepositorio<Avaliacao> Repositorio{get;set;}
        private IRepositorio<Aluno> AlunoRepositorio { get; set; }
        private IRepositorio<Resposta> RespostaRepositorio { get; set; }
        private IRepositorio<Questao> QuestaoRepositorio { get; set; }
        private IRepositorio<Questionario> QuestionarioRepositorio { get; set; }
        private IRepositorio<Modulo> ModuloRepositorio { get; set; }
        public ResponderController(IRepositorio<Avaliacao> _repositorio,
            IRepositorio<Aluno> _AlunoRepo,
            IRepositorio<Resposta> _respostaRepositorio,
            IRepositorio<Questao> _questaoRepositorio,
            IRepositorio<Questionario> _questionarioRepositorio,
            IRepositorio<Modulo> _ModuloRepositorio)
        {
            Repositorio = _repositorio;
            AlunoRepositorio = _AlunoRepo;
            RespostaRepositorio = _respostaRepositorio;
            QuestaoRepositorio = _questaoRepositorio;
            QuestionarioRepositorio = _questionarioRepositorio;
            ModuloRepositorio = _ModuloRepositorio;
        }

        public ActionResult Index()
        {
            QuestaoIndex = 0;
            var AlunoId = AlunoRepositorio.BuscarTodos()
                .Where(al => al.Login == User.Identity.Name).Select(al =>al.Id).FirstOrDefault();

            Guid[] AvaliacoesId = Repositorio.BuscarTodos()
                .Where(a => a.AlunoID == AlunoId)
                .Select(a => a.Id).ToArray();
            
            List<Avaliacao> list = new List<Avaliacao>();
            foreach (var item in AvaliacoesId)
            {
                Avaliacao aval = Repositorio.Buscar(item);

                if (aval.DataInicio.Date <= DateTime.Now.Date
                    && (!aval.DataTermino.HasValue
                    || aval.DataTermino.Value.Date > DateTime.Now.Date))
                    list.Add(aval);
            }

            return View(list);
        }

        private SelectList BuscaRespostasList(Escala valor)
        {
            var values = from Escala e in Enum.GetValues(typeof(Escala))
                         select new { Id = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name", Escala.SemResposta);
        }


        static Int32 QuestaoIndex = 0;
        [HttpGet]
        public ActionResult Responder(Guid id = default(Guid))
        {
            Avaliacao avaliacao = Repositorio.Buscar(id);

            if (avaliacao == null)
            {
                return HttpNotFound();
            }

            Questionario quest = QuestionarioRepositorio.Buscar(avaliacao.QuestionarioID);

            if (QuestaoIndex >= quest.Questoes.Count)
            {
                return RedirectToAction("Comentarios", new { ID = id });
            }

            Questao q = quest.Questoes
                .OrderBy(a => a.Texto)
                .ElementAt(QuestaoIndex);

            Resposta resp = RespostaRepositorio.BuscarTodos()
                 .Where(r => r.AvaliacaoID == avaliacao.Id && r.QuestaoID == q.Id)
                 .OrderByDescending(r => r.DataResposta).FirstOrDefault();

            if (resp != null)
                ViewBag.ValorRespostas = BuscaRespostasList((Escala)resp.Valor);
            else
                ViewBag.ValorRespostas = BuscaRespostasList(Escala.SemResposta);

            Session["QuestaoID"] = q.Id;
            Session["QuestionarioID"] = q.QuestionarioID;
            Session["AvaliacaoID"] = avaliacao.Id;

            return View(q);
        }

        [HttpPost]
        public ActionResult Responder(Questao questao, FormCollection form)
        {
            Resposta resposta = new Resposta();
            resposta.AvaliacaoID = (Guid)Session["AvaliacaoID"]; 
            resposta.QuestaoID = (Guid)Session["QuestaoID"];
            resposta.DataResposta = DateTime.Now;

            Escala valor;

            if (Escala.TryParse(form["ValorRespostas"], out valor))
            {
                resposta.EscolherResposta(valor);
                RespostaRepositorio.Incluir(resposta);
                QuestaoIndex++;
                return RedirectToAction("Responder");

            }                
                
            return RedirectToAction("Index");
        }

        public ActionResult Comentarios(Guid ID = default(Guid))
        {
            Avaliacao avaliacao = Repositorio.Buscar(ID);

            if (avaliacao == null)
            {
                return HttpNotFound();
            }

            return View(avaliacao);
        }

        [HttpPost]
        public ActionResult Comentarios(Avaliacao avaliacao)
        {
            string comentario = avaliacao.Comentarios;

            avaliacao = Repositorio.Buscar(avaliacao.Id);
            avaliacao.Comentarios = comentario;

            Repositorio.Atualizar(avaliacao);

            return RedirectToAction("Index");
        }

    }
}
