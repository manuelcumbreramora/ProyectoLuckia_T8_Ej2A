using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

using System.Web.Mvc;

namespace CelulaRiego.Filters
{
    public class AuthorizationApiFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext ctx)
        {
            string apiKey = getApiKey();
            if (apiKey != "gw6A25Z9G8BYyyciMetr2mzmhto6SQ72")
            {
                ctx.Result = new HttpStatusCodeResult(403, "ApiKey no válido");
            }

            base.OnActionExecuting(ctx);
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext ctx)
        {
            //throw new NotImplementedException();
        }

        private string getApiKey()
        {
            string reply = "";

            string authHeader = System.Web.HttpContext.Current.Request.Headers["Authorization"];

            if (authHeader == null || authHeader.Length == 0 || !authHeader.StartsWith("Basic")) return "";

            string base64Credentials = authHeader.Substring(6);
            string[] apiKey = Encoding.ASCII.GetString(Convert.FromBase64String(base64Credentials)).Split(new char[] { ':' });

            if (apiKey != null && apiKey.Length > 0)
                reply = apiKey[0];

            return reply;
        }
    }
}