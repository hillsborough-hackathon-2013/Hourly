using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hourly.Services.Areas.Api.Models
{
    public class RegisterDto
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public String FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public String LastName { get; set; }
        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public String UserName { get; set; }
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public String Password { get; set; }
        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public String EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the hours needed.
        /// </summary>
        public Int32 HoursNeeded { get; set; }
    }
}