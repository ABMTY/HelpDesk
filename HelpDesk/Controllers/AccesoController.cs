using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        //CtrlUsuarios ctrlUsuario = new CtrlUsuarios();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Usuario, string Password)
        {
            //List<EntUsuario> ListaUsuarios = new List<EntUsuario>();
            //ListaUsuarios = ctrlUsuario.ObtenerTodos();
            //EntUsuario entUsuario = new EntUsuario();

            //bool AccesoAutorizado = false;

            //foreach (var entUser in ListaUsuarios)
            //{
            //    if (entUser.usuario == Usuario && entUser.password == Password && entUser.id_empresa == id_Empresa)
            //    {
            //        AccesoAutorizado = true;
            //        entUsuario = entUser;
            //        break;
            //    }
            //}

            //if (AccesoAutorizado == true)
            //{
            //    Session["Id_Usuario"] = entUsuario.id_usuario;
            //    Session["Usuario"] = entUsuario.usuario;
            //    Session["Nombre"] = entUsuario.nombre;
            //    Session["Id_Empresa"] = entUsuario.id_empresa;
            //    Session["RazonSocial"] = entUsuario.razon_social;

            //    var cookie = new HttpCookie("Id_Usuario");
            //    cookie.Value = entUsuario.id_usuario.ToString();
            //    Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ViewBag.Message = string.Format("Usuario y/o Contraseña es Incorrecta!");
            //    return View();
            //}
        }




        public ActionResult CerrarSesion()
        {
            //Session.RemoveAll();
            //Session.Abandon();
            //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            //Response.AppendHeader("Cache-Control", "no-store");
            //Session["Id_Usuario"] = "";
            //Session["Usuario"] = "";
            //Session["Nombre"] = "";
            //Session["Id_Empresa"] = "";
            //Session["RazonSocial"] = "";
            //Response.Cookies.Clear();
            //Session.Clear();
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");
        }
    }
}