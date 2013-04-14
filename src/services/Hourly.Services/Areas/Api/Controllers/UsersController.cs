using Grandstand.Web.Mvc.Filters;
using Hourly.Domain;
using Hourly.Services.Areas.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebMatrix.WebData;

namespace Hourly.Services.Areas.Api.Controllers
{
    [InitializeSimpleMembership]
    public class UsersController : ApiController
    {
        private HourlyContext context = new HourlyContext();

        /// <summary>
        /// Logs in the user.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Login(LoginDto dto)
        {
            return this.HandleLogin(dto.UserName, dto.Password, dto.RememberMe);
        }
        /// <summary>
        /// Registers a user.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Register(RegisterDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(dto.UserName, dto.Password, new { dto.EmailAddress });
                    return this.HandleLogin(dto.UserName, dto.Password, rememberMe: false);
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed
            return Request.CreateResponse<Object>(HttpStatusCode.BadRequest, new { errors = GetErrorsFromModelState() });
        }
        /// <summary>
        /// Gets projects that are registered for a user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public HttpResponseMessage Projects(Int32 id)
        {
            var projects = (from u in context.Users
                            from p in u.Projects
                            where u.Id == id
                            select p.AsProjectSummaryDto())
                           .ToArray();

            return Request.CreateResponse(HttpStatusCode.OK, new { success = true, projects });
        }
        /// <summary>
        /// Gets or sets the projects that a user is managing
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public HttpResponseMessage MyProjects()
        {
            String userName = User.Identity.Name;

            var projects = (from p in context.Projects
                            where p.ProjectManager.UserName == userName
                            select p.AsProjectSummaryDto())
                           .ToArray();

            return Request.CreateResponse(HttpStatusCode.OK, new { success = true, projects });
        }
        /// <summary>
        /// Searches users using the specified keyword.
        /// </summary>
        [HttpGet]
        [Authorize]
        public HttpResponseMessage Search(String keyword)
        {
            var users = from u in context.Users
                        where u.UserName.Contains(keyword) ||
                              u.FirstName.Contains(keyword) ||
                              u.LastName.Contains(keyword) ||
                              u.EmailAddress.Contains(keyword)
                        select u.AsUserDto();

            return Request.CreateResponse(HttpStatusCode.OK, new { success = true, users });
        }

        /// <summary>
        /// Not applicable.
        /// </summary>
        [HttpGet]
        public void Test()
        {
        }
        
        #region Private Members
        private IEnumerable<String> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }
        private static String ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";
                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";
                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";
                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        private HttpResponseMessage HandleLogin(String userName, String password, Boolean rememberMe)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(userName, password, rememberMe))
                {
                    UserDto user = new UserDto();
                    user.UserName = userName;
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = true, user });
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            // If we got this far, something failed
            return Request.CreateResponse<Object>(HttpStatusCode.Unauthorized, new { errors = GetErrorsFromModelState() });
        }

        #endregion
    }
}
