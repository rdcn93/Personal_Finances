using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personal_Finances.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "dd507c99-5390-41d0-8f8a-d7c533bb6bbe",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "b64829c1-2c8b-4a5c-8ed5-a19b6e7634aa",
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                }
            );
        }
    }
}
