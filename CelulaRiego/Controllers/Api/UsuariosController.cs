using Celula.Extensions.Controllers;
using System.Data;
using System.Web.Mvc;
using Negocio;
using System.Collections.Generic;
using System;

namespace Celula.Controllers.Api
{
    //[AuthorizationApiFilter]


    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiBaseController
    {

        Sistema sistemaService = new Sistema();

        [HttpPost, Route("inicioSesion")]
        public ActionResult IdentificarUsuarios(string nombre, string pass)
        {
            Usuario usuario = sistemaService.VerificarLogin(nombre, pass);
            DataTable result = new DataTable();
            if (result != null)
            {
                System.Web.HttpContext.Current.Session["IdUsuario"] = usuario.GetIdUsuario().ToString();
                DataColumn colIds = new DataColumn("id");
                colIds.DataType = System.Type.GetType("System.Int32");
                result.Columns.Add(colIds);
                result.Rows.Add(new Object[] { usuario.GetIdUsuario().ToString() });
            }
            return result != null ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }

        [HttpPost, Route("registro")]
        public ActionResult RegistrarUsuarios(string nombre, string pass)
        {
            //User result = usuarioServicio.Identificacion(nombre, pass);
            Usuario usuario = sistemaService.CrearUsuario(nombre, pass);
            DataTable result = new DataTable();
            if (result != null)
            {
                System.Web.HttpContext.Current.Session["IdUsuario"] = usuario.GetIdUsuario().ToString();
                DataColumn colIds = new DataColumn("id");
                colIds.DataType = System.Type.GetType("System.Int32");
                result.Columns.Add(colIds);
                result.Rows.Add(new Object[] { usuario.GetIdUsuario().ToString() });
            }
            return result != null ? JsonSuccess(result) : JsonError("Error al guardar el usuario");
        }

    }

}
}