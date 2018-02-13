using CtrlHelpDesk.Catalogos;
using EntHelpDesk.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Controllers.Administracion
{
    public class TipoSoporteController : Controller
    {
        CtrlTipoSoporte control = new CtrlTipoSoporte();
        // GET: TipoSoporte
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(tipo_soporte entidad)
        {
            try
            {
                var r = entidad.id_tipo_soporte > 0 ?
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
                return View("Error", new HandleErrorInfo(ex, "TipoSoporte", "Create"));
            }
        }
        public ActionResult GetTipoSoportes()
        {
            var Lista = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Lista }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetTipoSoporte(int id)
        {
            var Entidad = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Entidad }, JsonRequestBehavior.AllowGet);
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
                return View("Error", new HandleErrorInfo(ex, "TipoSoporte", "Eliminar"));
            }
        }
    }
}