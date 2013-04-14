using Hourly.Models;
using System.Data.Entity;

namespace Hourly.Domain.Maps
{
    static class ProjectsMap
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Project>()
                .HasRequired(m => m.ProjectManager)
                .WithMany()
                .HasForeignKey(m => m.ProjectManagerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .Property(m => m.Description)
                .HasMaxLength(56)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .Property(m => m.ProjectHours)
                .IsOptional();
            
            modelBuilder.Entity<Project>().ToTable("Projects");
        }
    }
}
