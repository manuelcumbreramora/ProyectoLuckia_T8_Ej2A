﻿using Celula.Extensions.Controllers;
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
        public ActionResult RegistrarMonedero(int importe, string divisa, int idUsuario)
        {
            //Monedero monedero = sistemaService.CrearMonedero(importe, divisa, idUsuario);
            DataTable result = new DataTable();
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