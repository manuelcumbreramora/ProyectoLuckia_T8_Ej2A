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
    [RoutePrefix("api/transaccion")]
    public class TransaccionController : ApiBaseController
    {
        Sistema sistemaService = new Sistema();

        [HttpPost, Route("registro")]
        public ActionResult RegistrarTransaccion(int importeTransaccion, string tipoTransaccion, int idMonedero)
        {
            //User result = usuarioServicio.Identificacion(nombre, pass);
            Transaccion transaccion = sistemaService.InsertarTransaccion(importeTransaccion, idMonedero, tipoTransaccion);
            DataTable result = new DataTable();

            System.Web.HttpContext.Current.Session["idTransaccion"] = transaccion.GetIdTransaccion().ToString();
            DataColumn colIds = new DataColumn("id");
            colIds.DataType = System.Type.GetType("System.Int32");
            result.Columns.Add(colIds);
            result.Rows.Add(new Object[] { transaccion.GetIdTransaccion().ToString() });

            return transaccion != null ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }

        [HttpPost, Route("listarHistorialTransacciones")]
        public ActionResult HistorialTransacciones(int idUsuario)
        {
            List<Transaccion> historialTransacciones = sistemaService.RecuperarListaTransaccionPorIdUsuario(idUsuario);
            DataTable result = new DataTable();

            /*System.Web.HttpContext.Current.Session["transacciones"] = historialTransacciones;
            DataColumn colIds = new DataColumn("transacciones");
            colIds.DataType = System.Type.GetType("System.Object");
            result.Columns.Add(colIds);
            result.Rows.Add(new Object[] { historialTransacciones });*/

            return historialTransacciones.Count() > 0 ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }
    }
}