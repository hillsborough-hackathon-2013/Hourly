using Hourly.Models;
using System;

namespace Hourly.Services.Areas.Api.Models
{
    public class ProjectDto
    {
        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// Gets or sets the project description.
        /// </summary>
        public String ProjectDescription { get; set; }
    }

    public static class ProjectExtensions
    {
        public static ProjectDto AsProjectDto(this Project project)
        {
            throw new NotImplementedException("Not yet implemented.");
        }
    }
}