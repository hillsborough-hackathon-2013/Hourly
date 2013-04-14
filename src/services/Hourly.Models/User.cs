using System;
using System.Collections.Generic;

namespace Hourly.Models
{
    public class User
    {
        /// <summary>
        /// Gets or sets the user's id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public String UserName { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public String FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public String LastName { get; set; }
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public String EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the number of hours that are needed.
        /// </summary>
        public Int32 HoursNeeded { get; set; }
        /// <summary>
        /// Gets or sets the projects that the user is registered to.
        /// </summary>
        public virtual ICollection<Project> Projects { get; set; }
    }
}
