using System;

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
        /// Gets or sets the email address.
        /// </summary>
        public String EmailAddress { get; set; }
    }
}
