using System;

namespace Hourly.Services.Areas.Api.Models
{
    public class UserDto
    {
        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public String UserName { get; set; }
    }
}