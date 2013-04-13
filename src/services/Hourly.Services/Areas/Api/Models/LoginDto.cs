using System;
using System.ComponentModel.DataAnnotations;

namespace Hourly.Services.Areas.Api.Models
{
    public class LoginDto
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required(ErrorMessage = "The username is a required field.")]
        public String UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required(ErrorMessage = "The password is a required field.")]
        public String Password { get; set; }
        /// <summary>
        /// Gets or sets a boolean indicating whether the user should be remembered.
        /// </summary>
        public Boolean RememberMe { get; set; }
    }
}