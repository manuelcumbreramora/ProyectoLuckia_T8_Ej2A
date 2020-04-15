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
        public ActionResult RegistrarTransaccion(int importe, int idMonedero, string tipo)
        {
            //User result = usuarioServicio.Identificacion(nombre, pass);
            Transaccion transaccion = sistemaService.InsertarTransaccion(importe, idMonedero, tipo);
            DataTable result = new DataTable();
            return result != null ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }

        [HttpPost, Route("listarHistorialTransacciones")]
        public ActionResult HistorialTransacciones(int idUsuario)
        {
            List<Transaccion> historialTransacciones = sistemaService.RecuperarListaTransaccionPorIdUsuario(idUsuario);
            DataTable result = new DataTable();
            return result != null ? JsonSuccess(result) : JsonError("Error al cargar usuario");
        }
    }
}