using CtrlHelpDesk.Catalogos;
using EntHelpDesk.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HelpDesk.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        CtrlUsuarios ctrlUsuario = new CtrlUsuarios();
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
                Session["tipo_usuario"] = entUsuario.tipo_usuario;
                Session["nombre_completo"] = entUsuario.nombre_completo;
                Session["id_sucursal"] = entUsuario.id_sucursal;
                Session["sucursal"] = entUsuario.sucursal;
                Session["foto"] = "data:image/png;base64,"+entUsuario.foto;

                var cookie = new HttpCookie("id_usuario");
                cookie.Value = entUsuario.id_usuario.ToString();
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
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
            Response.Cookies.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");
        }
    }
}