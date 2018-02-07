using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Controllers.Proceso
{
    public class TiketsController : Controller
    {
        // GET: Tikets
        public ActionResult Index()
        {
            return View();
        }
    }
}