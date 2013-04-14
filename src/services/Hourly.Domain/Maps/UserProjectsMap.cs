using Hourly.Models;
using System.Data.Entity;

namespace Hourly.Domain.Maps
{
    class UserProjectsMap
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(m => m.Projects)
                .WithMany(m => m.Users)
                .Map(m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("ProjectId");
                        m.ToTable("UserProjects");
                    }
                );
        }
    }
}
