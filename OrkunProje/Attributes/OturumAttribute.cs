using BL.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrkunProje.Attributes
{
    public class OturumAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionKontrol.Kontrol == null)
            {
                HttpContext.Current.Response.Redirect("/login");
            }
        }
    }
}