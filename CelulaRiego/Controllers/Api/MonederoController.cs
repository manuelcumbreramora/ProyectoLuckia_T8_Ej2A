using Celula.Extensions.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using System.Data;

namespace CelulaRiego.Controllers.Api
{
    [RoutePrefix("api/monedero")]
    public class MonederoController : ApiBaseController
    {
        Sistema sistemaService = new Sistema();

        [HttpPost, Route("registro")]
        public ActionResult RegistrarMonedero(int importeMonedero, string divisaMonedero, int idUsuario)
        {
            //Monedero monedero = sistemaService.CrearMonedero(importe, divisa, idUsuario);
            DataTable result = new DataTable();

            /*System.Web.HttpContext.Current.Session["idMonedero"] = mondero.GetIdMonedero().ToString();
            DataColumn colIds = new DataColumn("id");
            colIds.DataType = System.Type.GetType("System.Int32");
            result.Columns.Add(colIds);
            result.Rows.Add(new Object[] { mondero.GetIdMonedero().ToString() });*/

            return result != null ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }

        [HttpPost, Route("consultar")]
        public ActionResult ConsultarMonedero(int idMonedero)
        {
            //Monedero monedero = sistemaService.RecuperarMonedero(idMonedero);
            DataTable result = new DataTable();
            return result != null ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }

    }
}