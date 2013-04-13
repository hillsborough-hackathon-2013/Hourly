using Hourly.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hourly.Domain.Maps
{
    static class UserMap
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<User>()
                .Property(m => m.UserName)
                .HasMaxLength(56)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(m => m.EmailAddress)
                .HasMaxLength(56)
                .IsRequired();

            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
