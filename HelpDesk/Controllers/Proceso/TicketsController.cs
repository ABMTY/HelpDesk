using CtrlHelpDesk.Catalogos;
using CtrlHelpDesk.Servicios;
using EntHelpDesk.Entidad;
using HelpDesk.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace HelpDesk.Controllers.Proceso
{
    public class TicketsController : Controller
    {
        CtrlTickets control = new CtrlTickets();
        CtrlDetalleTicket ctrlDetalle = new CtrlDetalleTicket();
        CtrlPrioridad ctrlPrioridad = new CtrlPrioridad();
        CtrlEstado ctrlEstado = new CtrlEstado();
        CtrlComentarios ctrlComentario = new CtrlComentarios();
        CtrlUsuarios ctrlUsuarios = new CtrlUsuarios();

        // GET: Tickets
        public ActionResult Index()
        {
            Session["id_detalle_ticket"] = 0;
            return View();
        }

        public ActionResult IndexSucursal()
        {
            return View();
        }        

        public ActionResult SeguimientoSucursal()
        {
            return View();
        }

        public ActionResult IndexMesaAyuda()
        {
            return View();
        }

        public ActionResult SeguimientoMesaAyuda()
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
                    int id_ticket = control.ObtenerMax();
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

        public ActionResult Guardar_EnMA(tickets entidad)
        {
            var r = false;
            try
            {
                if (entidad.id_ticket > 0)
                {
                    entidad.id_sucursal = ctrlUsuarios.Obtener(entidad.id_usuario).id_sucursal;
                    r = control.Actualizar(entidad);
                    r = ctrlDetalle.Actualizar(entidad);
                }
                else
                {
                    entidad.id_sucursal = ctrlUsuarios.Obtener(entidad.id_usuario).id_sucursal;                    
                    r = control.Insertar(entidad);
                    int id_ticket = control.ObtenerMax();
                    ctrlDetalle.Insertar(new detalle_ticket
                    {
                        id_ticket = id_ticket,
                        id_area = entidad.id_area,
                        id_prioridad = entidad.id_prioridad,
                        id_estado = entidad.id_estado,
                        id_agente= entidad.id_agente,                        
                        id_tipo_soporte = entidad.id_tipo_soporte,
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

        public ActionResult ActualizarPorMA(tickets entidad)
        {
            var r = false;
            try
            {

                ctrlDetalle.ActualizarPorMA(new detalle_ticket
                {
                    id_detalle_ticket=entidad.id_detalle_ticket,
                    id_ticket = entidad.id_ticket,                    
                    id_prioridad = entidad.id_prioridad,
                    id_estado = entidad.id_estado,
                    id_agente = entidad.id_agente,                    
                });

                if (!r)
                {
                    return Json("Error al realizar la operacion", JsonRequestBehavior.AllowGet);
                }

                return Json("Realizado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Detalle_Ticket", "Update por MA"));
            }
        }

        public ActionResult GetEsadosTickets()
        {
            tickets entidad = new tickets();
            usuarios usuario = new usuarios();
            int id_usuario = int.Parse(Session["id_usuario"].ToString());
            usuario = ctrlUsuarios.Obtener(id_usuario);
            entidad = control.ObtenerEstados(usuario);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = entidad }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetTickets()
        {
            List<tickets> Listado = new List<tickets>();
            int id_usuario = int.Parse(Session["id_usuario"].ToString());
            usuarios usuario = new usuarios();
            usuario = ctrlUsuarios.Obtener(id_usuario);

            switch (usuario.tipo_usuario.ToUpper())
            {
                    case "SUPERVISOR" :  Listado = control.ObtenerPorUsuario(id_usuario);
                        break;
                    case "AGENTE":
                        Listado = control.ObtenerTodos().Where(p=> p.id_agente==id_usuario).ToList();
                        break;
                default : Listado = control.ObtenerTodos();
                        break;
            }

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Listado }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public ActionResult GetNotificacion()
        {
            List<notificaciones> Listado = new List<notificaciones>();
            int id_usuario = int.Parse(Session["id_usuario"].ToString());
            usuarios usuario = new usuarios();
            usuario = ctrlUsuarios.Obtener(id_usuario);

            switch (usuario.tipo_usuario.ToUpper())
            {
                case "SUPERVISOR":
                    Listado = control.ObtenerNotifyUser(id_usuario);
                    break;
                case "AGENTE":
                    Listado = control.ObtenerNotifyUser(id_usuario);
                    break;
                default:
                    Listado = control.ObtenerNotify();
                    break;
            }

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Listado }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public ActionResult GetTicket(int id)
        {            
            var Listado = control.Obtener(id);
            //Session["id_detalle_ticket"] = ((tickets)Listado).id_detalle_ticket;
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

        public ActionResult GuardarComentario(comentarios entidad)
        {
            var r = false;
            try
            {
                r = ctrlComentario.Insertar(entidad);

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
    }
}