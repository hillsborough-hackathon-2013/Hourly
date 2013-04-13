using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hourly.Services.Areas.Api.Controllers
{
    public class ProjectsController : ApiController
    {
        // GET api/users
        public IEnumerable<String> Get()
        {
            return new String[] { "project1", "project2" };
        }

        // GET api/users/5
        public String Get(int id)
        {
            return "value";
        }

        // POST api/users
        public void Post([FromBody]String value)
        {
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]String value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}
