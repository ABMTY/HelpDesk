using CtrlHelpDesk.Catalogos;
using EntHelpDesk.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace HelpDesk.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        CtrlUsuarios ctrlUsuario = new CtrlUsuarios();
        string controlador;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Usuario, string Password)
        {
            List<usuarios> ListaUsuarios = new List<usuarios>();
            ListaUsuarios = ctrlUsuario.ObtenerTodos();
            usuarios entUsuario = new usuarios();

            

            bool AccesoAutorizado = false;

            foreach (var entUser in ListaUsuarios)
            {
                if (entUser.user_name == Usuario && entUser.password == Password )
                {
                    AccesoAutorizado = true;
                    entUsuario = entUser;
                    break;
                }
            }

            if (AccesoAutorizado == true)
            {
                Session["id_usuario"] = entUsuario.id_usuario;
                Session["user_name"] = entUsuario.user_name;
                Session["password"] = entUsuario.password;
                Session["tipo_usuario"] = entUsuario.tipo_usuario;
                Session["nombre_completo"] = entUsuario.nombre_completo;
                Session["id_sucursal"] = entUsuario.id_sucursal;
                Session["sucursal"] = entUsuario.sucursal;
                Session["id_tipo_usuario"] = entUsuario.id_tipo_usuario;
                Session["foto"] = "data:image/png;base64,"+entUsuario.foto;                
                var cookie = new HttpCookie("id_usuario");
                cookie.Value = entUsuario.id_usuario.ToString();
                Response.Cookies.Add(cookie);

                if (entUsuario.tipo_usuario == "Gerente" || entUsuario.tipo_usuario == "Administrador")
                {
                    controlador = "Dashboard";
                }                
                if (entUsuario.tipo_usuario == "Agente")
                {
                    controlador = "Tickets/IndexMesaAyuda";
                }
                if (entUsuario.tipo_usuario == "Supervisor")
                {
                    controlador = "Tickets/IndexSucursal";
                }

                return RedirectToAction("Index", controlador);
            }
            else
            {
                ViewBag.Message = string.Format("Usuario y/o Contraseña es Incorrecta!");
                return View();
            }
        }




        public ActionResult CerrarSesion()
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.AppendHeader("Cache-Control", "no-store");
            Session["id_usuario"] = "";
            Session["tipo_usuario"] = "";
            Session["nombre_completo"] = "";
            Session["id_sucursal"] = "";
            Session["sucursal"] = "";
            Session["foto"] = "";
            Session["id_tipo_usuario"] = "";
            Session["user_name"] = "";
            Session["password"] = "";
            Response.Cookies.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");
        }
        
    }
}