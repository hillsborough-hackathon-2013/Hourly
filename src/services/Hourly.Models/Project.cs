using System;
using System.Collections.Generic;

namespace Hourly.Models
{
    public class Project
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// Gets or sets the project manager id.
        /// </summary>
        public Int32 ProjectManagerId { get; set; }
        /// <summary>
        /// Gets or sets the project description.
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Gets or sets the project's hours.
        /// </summary>
        public Int32 ProjectHours { get; set; }
        /// <summary>
        /// Gets or sets the project manager.
        /// </summary>
        public User ProjectManager { get; set; }
        /// <summary>
        /// Gets the users who are registered for a project.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
