using Hourly.Models;
using System;
using System.Linq;

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
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public String FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public String LastName { get; set; }
        /// <summary>
        /// Gets or sets the hours needed.
        /// </summary>
        public Int32 HoursNeeded { get; set; }
        /// <summary>
        /// Gets or sets the hours committed.
        /// </summary>
        public Int32 HoursCommitted { get; set; }
    }

    public static class UserExtensions
    {
        public static UserDto AsUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                LastName = user.LastName,
                UserName = user.UserName,
                FirstName = user.FirstName,
                HoursNeeded = user.HoursNeeded,
                HoursCommitted = user.Projects.Sum(p => p.ProjectHours),
            };
        }
    }
}