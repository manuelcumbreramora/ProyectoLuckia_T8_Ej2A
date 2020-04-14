using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class MonederoController : Controller
    {
        // GET: Monedero
        public ActionResult Index()
        {
            return View();
        }
    }
}