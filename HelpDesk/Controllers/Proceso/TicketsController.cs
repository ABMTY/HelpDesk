﻿using CtrlHelpDesk.Catalogos;
using CtrlHelpDesk.Servicios;
using EntHelpDesk.Entidad;
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

        public ActionResult Guardar_EnMA(tickets entidad)
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
                    entidad.id_sucursal = ctrlUsuarios.Obtener(entidad.id_usuario).id_sucursal;                    
                    r = control.Insertar(entidad);
                    int id_ticket = control.ObtenerTodos().ToList().Max(p => p.id_ticket);                    
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