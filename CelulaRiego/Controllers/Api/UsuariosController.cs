using Celula.Application.Services.Usuario;
using Celula.Extensions.Controllers;
using System.Data;
using System.Web.Mvc;

namespace Celula.Controllers.Api
{
    //[AuthorizationApiFilter]


    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiBaseController
    {

        [HttpPost, Route("indentificacion")]
        public ActionResult IdentificarUsuarios(string nombre, string pass)
        {
            UsuarioService usuarioServicio = new UsuarioService();
            var result = usuarioServicio.Identificacion(nombre, pass);
            return result != null ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }

        [HttpPost, Route("registro")]
        public ActionResult RegistrarUsuarios(string nombre, string pass)
        {
            //User result = usuarioServicio.Identificacion(nombre, pass);
            DataTable result = new DataTable();
            /*if (result != null)
            {
                System.Web.HttpContext.Current.Session["IdUsuario"] = result.id.ToString();
                System.Web.HttpContext.Current.Session["NombreUsuario"] = result.usuario;
                DataColumn colIds = new DataColumn("id");
                colIds.DataType = System.Type.GetType("System.Int32");
                usuario.Columns.Add(colIds);
                DataColumn colNombre = new DataColumn("nombre");
                colNombre.DataType = System.Type.GetType("System.String");
                usuario.Columns.Add(colNombre);
                usuario.Rows.Add(new Object[] { result.id.ToString(), result.usuario });
            }*/
            return result != null ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }

    }
}