using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personal_Finances.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finances.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "416f2bf3-e224-42df-b0ab-0a0b159b7cfb",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Name = "Raul",
                    LastName = "Castañeda",
                    UserName = "rdcn93",
                    NormalizedUserName = "rdcn93",
                    PasswordHash = hasher.HashPassword(null, "Rcastaneda93$"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "b7d8f5eb-0fc3-4fb9-b4f9-47f0f4c2b4fc",
                    Email = "juanperez@localhost.com",
                    NormalizedEmail = "juanperez@localhost.com",
                    Name = "Juan",
                    LastName = "Perez",
                    UserName = "juanperez",
                    NormalizedUserName = "juanperez",
                    PasswordHash = hasher.HashPassword(null, "Rcastaneda93$"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
