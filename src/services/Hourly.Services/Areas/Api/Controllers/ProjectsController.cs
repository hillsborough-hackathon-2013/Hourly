using Hourly.Domain;
using Hourly.Models;
using Hourly.Services.Areas.Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hourly.Services.Areas.Api.Controllers
{
    [Authorize]
    public class ProjectsController : ApiController
    {
        private HourlyContext context = new HourlyContext();

        // GET api/projects
        /// <summary>
        /// Lists the projects for a user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectSummaryDto> Index()
        {
            return (from u in context.Users
                    where u.UserName == User.Identity.Name
                    select u)
                    .SelectMany(u => u.Projects)
                    .Select(p => p.AsProjectSummaryDto());
        }
        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Update(ProjectDto dto)
        {
            if (dto != null)
            {
                Project project = dto.ToEntity();
                context.Projects.Attach(project);

                context.Entry(project).State = EntityState.Modified;

                try
                {
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, new { successful = true, project = project.AsProjectDto() });
                }
                catch (DBConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        /// <summary>
        /// Creates a project.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Create(ProjectDto dto)
        {
            String userName = User.Identity.Name;

            if (dto != null)
            {
                User user = context.Users.Where(u => u.UserName == userName).First();
                Project project = dto.ToEntity();
                
                project.ProjectManager = user;

                context.Projects.Add(project);

                try
                {
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, new { successful = true, project = project.AsProjectDto() });
                }
                catch (DBConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // GET api/projects/5
        /// <summary>
        /// Gets a project using the specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Index(Int32 id)
        {
            Project project = (from p in context.Projects
                               from u in p.Users
                               where p.Id == id && u.UserName == User.Identity.Name
                               select p)
                              .FirstOrDefault();

            if (project != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, project = project.AsProjectDto() });
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, new { error = "Either the project was not found or you do not have access to it." });
        }
        // GET api/projects/5/register
        /// <summary>
        /// Registers a user from a project.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Register(Int32 id)
        {
            String userName = User.Identity.Name;

            Project project = (from p in context.Projects
                               from u in p.Users
                               where p.Id == id
                               select p)
                              .FirstOrDefault();

            if (project != null)
            {
                if (!project.Users.Any(u => u.UserName == userName))
                {
                    try
                    {
                        User user = (from u in context.Users
                                     where u.UserName == userName
                                     select u)
                                    .First();

                        project.Users.Add(user);
                        context.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, new { successful = true, project = project.AsProjectDto() });
                    }
                    catch (DbUpdateConcurrencyException e)
                    {
                        ModelState.AddModelError("", e);
                    }
                }
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage UnRegister(Int32 id)
        {
            String userName = User.Identity.Name;

            Project project = (from p in context.Projects
                               from u in p.Users
                               where p.Id == id
                               select p)
                              .FirstOrDefault();

            if (project != null)
            {
                if (!project.Users.Any(u => u.UserName == userName))
                {
                    try
                    {
                        User user = (from u in context.Users
                                     where u.UserName == userName
                                     select u)
                                    .First();

                        project.Users.Remove(user);
                        context.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, new { successful = true, project = project.AsProjectDto() });
                    }
                    catch (DbUpdateConcurrencyException e)
                    {
                        ModelState.AddModelError("", e);
                    }
                }
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
