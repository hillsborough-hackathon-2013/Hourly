using Hourly.Models;
using System;

namespace Hourly.Services.Areas.Api.Models
{
    public class ProjectSummaryDto
    {
        public ProjectSummaryDto()
        {

        }
        public ProjectSummaryDto(Project project)
        {
            this.Id = project.Id;
            this.Description = project.Description;
            this.ProjectHours = project.ProjectHours;
            this.RegisteredUserCount = project.Users.Count;
        }
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
        public ProjectDto()
        {

        }
        public ProjectDto(Project project)
        {
            this.Id = project.Id;
            this.Description = project.Description;
            this.ProjectHours = project.ProjectHours;
        }

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