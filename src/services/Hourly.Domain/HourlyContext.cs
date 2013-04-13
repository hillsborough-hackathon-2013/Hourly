using Hourly.Domain.Maps;
using Hourly.Models;
using System.Data.Entity;

namespace Hourly.Domain
{
    public class HourlyContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HourlyContext"/>.
        /// </summary>
        public HourlyContext() : base("DefaultConnection") { }

        /// <summary>
        /// Gets or sets the DbSet that represents a <see cref="User"/>.
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Gets or sets the DbSet that represents a <see cref="Project"/>.
        /// </summary>
        //public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            UserMap.Map(modelBuilder);
        }
    }
}
