using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personal_Finances.Infrastructure.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "dd507c99-5390-41d0-8f8a-d7c533bb6bbe",
                    UserId = "416f2bf3-e224-42df-b0ab-0a0b159b7cfb"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "b64829c1-2c8b-4a5c-8ed5-a19b6e7634aa",
                    UserId = "b7d8f5eb-0fc3-4fb9-b4f9-47f0f4c2b4fc"
                }
            );
        }
    }
}
