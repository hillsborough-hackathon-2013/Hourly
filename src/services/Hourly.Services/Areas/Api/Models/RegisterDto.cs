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
        /// Gets or sets the usern name
        /// </summary>
        [Required(ErrorMessage = "The username is a required field.")]
        public String UserName { get; set; }
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        [Required(ErrorMessage = "The password is a required field.")]
        public String Password { get; set; }
        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public String EmailAddress { get; set; }
    }
}