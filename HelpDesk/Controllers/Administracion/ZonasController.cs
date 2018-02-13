using CtrlHelpDesk.Catalogos;
using EntHelpDesk.Entidad;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Controllers.Administracion
{
    public class ZonasController : Controller
    {
        CtrlZonas control = new CtrlZonas();
        // GET: Zonas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntHelpDesk.Entidad.zonas entidad)
        {
            bool r = false;
            try
            {
                 r = entidad.id_zona > 0 ?
                   control.Actualizar(entidad) :
                   control.Insertar(entidad);
                
                if (!r)
                {
                    return Json("Error al realizar la operacion", JsonRequestBehavior.AllowGet);
                }

                return Json("Realizado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Zonas", "Create"));
            }
        }
        public ActionResult GetZonas()
        {
            var Turnos = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Turnos }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetZona(int id)
        {
            var Turno = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Turno }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult Eliminar(int id)
        {
            try
            {
                var r = control.Eliminar(id);

                if (!r)
                {
                    return Json("Error al realizar la operacion", JsonRequestBehavior.AllowGet);
                }

                return Json("Realizado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Zona", "Eliminar"));
            }
        }
    }
}