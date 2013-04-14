using Hourly.Models;
using System;

namespace Hourly.Services.Areas.Api.Models
{
    public class ProjectSummaryDto
    {
        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// Gets or sets the project description.
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Gets or sets the project hours.
        /// </summary>
        public Int32 ProjectHours { get; set; }
        /// <summary>
        /// Gets or sets the number of registered users.
        /// </summary>
        public Int32 RegisteredUserCount { get; set; }
    }

    public class ProjectDto
    {
        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// Gets or sets the project description.
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Gets or sets the project hours.
        /// </summary>
        public Int32 ProjectHours { get; set; }
    }

    public static class ProjectExtensions
    {
        public static ProjectSummaryDto AsProjectSummaryDto(this Project project)
        {
            return new ProjectSummaryDto
            {
                 Id = project.Id,
                 Description = project.Description,
                 ProjectHours = project.ProjectHours,
                 RegisteredUserCount = project.Users.Count,
            };
        }
        public static ProjectDto AsProjectDto(this Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Description = project.Description,
                ProjectHours = project.ProjectHours,
            };
        }

        public static Project ToEntity(this ProjectDto dto)
        {
            return new Project
            {
                Id = dto.Id,
                Description = dto.Description,
                ProjectHours = dto.ProjectHours,
            };
        }
    }
}