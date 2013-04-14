using System.Web.Mvc;
using System.Web.Http;
namespace Hourly.Services.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                name: "project-register-user",
                routeTemplate: "api/projects/{id}/register",
                defaults: new { controller = "Projects", action = "Register" }
            );

            context.Routes.MapHttpRoute(
                name: "project-list-projects",
                routeTemplate: "api/projects/{id}",
                defaults: new { controller = "Projects", action = "Index", id = RouteParameter.Optional }
            );

            context.Routes.MapHttpRoute(
                name: "users-get-projects",
                routeTemplate: "api/users/{id}/projects",
                defaults: new { controller = "Users", action = "Projects" }
            );

            context.Routes.MapHttpRoute(
                name: "default-users",
                routeTemplate: "api/users/{action}",
                defaults: new { controller = "Users" }
            );
        }
    }
}
