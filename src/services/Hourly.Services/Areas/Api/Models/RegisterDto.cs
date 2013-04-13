using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hourly.Services.Areas.Api.Models
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "The username is a required field.")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "The password is a required field.")]
        public String Password { get; set; }
        public String EmailAddress { get; set; }
    }
}