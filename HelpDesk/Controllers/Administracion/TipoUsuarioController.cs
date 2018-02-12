using CtrlHelpDesk.Catalogos;
using EntHelpDesk.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Controllers.Administracion
{
    public class TipoUsuarioController : Controller
    {
        CtrlTipoUsuario control = new CtrlTipoUsuario();
        CtrlDetallePermiso ctrlDetPermisos = new CtrlDetallePermiso();
        CtrlPermisos ctrlpermisos = new CtrlPermisos();
        // GET: TipoUsuario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(tipo_usuario entidad)
        {
            var r = false;
            try
            {
                if (entidad.id_tipo_usuario > 0)
                {
                    r = control.Actualizar(entidad);
                    ctrlDetPermisos.Eliminar(entidad.id_tipo_usuario);
                    foreach (detalle_permiso item in entidad.permisos_tipo_usuario)
                    {
                        ctrlDetPermisos.Insertar(new detalle_permiso
                        {
                            id_tipo_usuario = entidad.id_tipo_usuario,
                            id_permiso = item.id_permiso
                        });
                    }
                }
                else
                {
                    r = control.Insertar(entidad);
                    int id_tipo_usuario = control.ObtenerTodos().ToList().Max(p => p.id_tipo_usuario);
                    foreach (detalle_permiso item in entidad.permisos_tipo_usuario)
                    {
                        ctrlDetPermisos.Insertar(new detalle_permiso
                        {
                            id_tipo_usuario = id_tipo_usuario,
                            id_permiso = item.id_permiso
                        });
                    }
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
        public ActionResult GetTipoUsuarios()
        {
            var Turnos = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Turnos }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetTipoUsuario(int id)
        {
            var Listado = control.Obtener(id);
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
        public ActionResult GetPermisoUsuarios(int id)
        {
            var Permisos = ctrlpermisos.ObtenerTodos();
            var TipoUsuario = control.Obtener(id);

            bool bandera = false;

            foreach (var itemPermiso in Permisos)
            {
                foreach (var itemPermisos in TipoUsuario.permisos_tipo_usuario)
                {

                    if (itemPermisos.id_permiso == itemPermiso.id_permiso)
                    {
                        itemPermiso.selected = "checked='checked'" + "&" + itemPermiso.id_permiso;
                        bandera = true;
                    }
                }

                if (bandera == false)
                {
                    itemPermiso.selected = " &" + itemPermiso.id_permiso.ToString();
                }
                bandera = false;
            }

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Permisos }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
    }
}