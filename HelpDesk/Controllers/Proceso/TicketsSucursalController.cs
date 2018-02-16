using CtrlHelpDesk.Catalogos;
using CtrlHelpDesk.Servicios;
using EntHelpDesk.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Controllers.Proceso
{
    public class TicketsSucursalController : Controller
    {
        CtrlTickets control = new CtrlTickets();
        CtrlDetalleTicket ctrlDetalle = new CtrlDetalleTicket();
        CtrlPrioridad ctrlPrioridad = new CtrlPrioridad();
        CtrlEstado ctrlEstado = new CtrlEstado();
        CtrlComentarios ctrlComentario = new CtrlComentarios();

        // GET: TicketsSucursal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(tickets entidad)
        {
            var r = false;
            try
            {
                if (entidad.id_ticket > 0)
                {
                    r = control.Actualizar(entidad);                   
                }
                else
                {
                    r = control.Insertar(entidad);
                    int id_ticket = control.ObtenerTodos().ToList().Max(p => p.id_ticket);
                    int id_prioridad = (ctrlPrioridad.ObtenerTodos().Find(x => x.nombre.ToUpper() == "BAJA") as prioridad).id_prioridad;
                    int id_estado = (ctrlEstado.ObtenerTodos().Find(x => x.nombre.ToUpper() == "ABIERTO") as estado).id_estado;
                    ctrlDetalle.InsertarPorSucursal(new detalle_ticket
                        {
                            id_ticket = id_ticket,
                            id_prioridad = id_prioridad,
                            id_estado = id_estado
                    });
                   
                }

                if (!r)
                {
                    return Json("Error al realizar la operacion", JsonRequestBehavior.AllowGet);
                }

                return Json("Realizado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "TipoUsuario", "Create"));
            }
        }
        public ActionResult GetTickets()
        {
            var Listado = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Listado }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetTicket(int id)
        {
            var Listado = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Listado }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetTicketPorUsuario(int id)
        {
            var Listado = control.ObtenerPorUsuario(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Listado }, JsonRequestBehavior.AllowGet);
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
                return View("Error", new HandleErrorInfo(ex, "TipoUsuario", "Eliminar"));
            }
        }
        public ActionResult GetDetalleTicket(int id)
        {
            var Detalle = ctrlDetalle.Obtener(id);                       

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Detalle }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetComentarioPorDetalle(int id)
        {
            var Comentarios = ctrlComentario.ObtenerPorDetalle(id);

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Comentarios }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
    }
}