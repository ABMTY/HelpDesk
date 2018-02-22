using CtrlHelpDesk.Catalogos;
using EntHelpDesk.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Controllers.Administracion
{
    public class MenuPrincipalController : Controller
    {
        CtrlMenuPrincipal ctrlMenuPrincipal = new CtrlMenuPrincipal();
        // GET: MenuPrincipal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMenuPrincipal()
        {   
            var LMenuPrincipal = ctrlMenuPrincipal.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = LMenuPrincipal }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
    }
}