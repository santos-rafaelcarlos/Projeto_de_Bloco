using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBloco.Webapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Quem Somos";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contate-nos.";

            return View();
        }
    }
}
