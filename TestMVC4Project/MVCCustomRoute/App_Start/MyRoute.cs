using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCCustomRoute.App_Start
{
    public class MyRoute:RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            if (httpContext.Request.UserAgent.IndexOf("MSIE") >= 0)
            {
                
                RouteData data = new RouteData(this, new MvcRouteHandler());
                data.Values.Add("controller", "Home");
                data.Values.Add("action", "Limit");
                return data;
            }
            else
                return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            if (values.ContainsKey("applay") && values["applay"] == "IE")
            {
                return new VirtualPathData(this, "IE/Index");
            }
            return null;
        }
    }
}