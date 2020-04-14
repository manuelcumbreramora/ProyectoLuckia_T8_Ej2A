using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Presentacion.Extensions.Controllers;

namespace Presentacion.Controllers
{

    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiBaseController
    {
        public ActionResult Index()
        {
            return View("Registro");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost, Route("registro")]
        public ActionResult RegistrarUsuario(string nombre, string pass)
        {
            //User usuario = usuarioServicio.Identificacion(nombre, pass);
            DataTable result = new DataTable();
            return result != null ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }
    }
}