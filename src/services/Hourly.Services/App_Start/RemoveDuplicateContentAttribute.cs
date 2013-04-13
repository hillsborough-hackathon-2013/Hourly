using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hourly.Services
{
    public class RemoveDuplicateContentAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.HttpContext.Request;

            if (!filterContext.IsChildAction && !request.IsAjaxRequest())
            {
                var routes = RouteTable.Routes;
                var requestContext = filterContext.RequestContext;
                var routeData = requestContext.RouteData;
                var dataTokens = routeData.DataTokens;

                if (dataTokens["area"] == null)
                {
                    dataTokens.Add("area", "");
                }

                VirtualPathData vpd = routes.GetVirtualPathForArea(requestContext, routeData.Values);
                if (vpd != null)
                {
                    String virtualPath = vpd.VirtualPath.ToLower();
                    if (!string.Equals(virtualPath, request.Path))
                    {
                        filterContext.Result = new RedirectResult(virtualPath + request.Url.Query, true);
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}