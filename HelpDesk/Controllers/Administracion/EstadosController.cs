using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Controllers.Administracion
{
    public class EstadosController : Controller
    {
        // GET: Estados
        public ActionResult Index()
        {
            return View();
        }
    }
}