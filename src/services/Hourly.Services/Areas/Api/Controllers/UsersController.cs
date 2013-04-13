using Grandstand.Web.Mvc.Filters;
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
        // GET api/users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        public HttpResponseMessage Login(LoginDto dto)
        {
            return this.HandleLogin(dto.UserName, dto.Password, dto.RememberMe);
        }
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

        #region Private Members
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
        #endregion
    }
}
