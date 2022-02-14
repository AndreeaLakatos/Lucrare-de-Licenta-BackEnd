using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalAdoption.Data.Entities
{
    public class UserRoles : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder) => builder.HasData(
            new IdentityRole
            {
                Id = "0770c9f0-42a9-485f-a95f-2b36ef3c6614",
                Name = "BasicUser",
                NormalizedName = "BASICUSER",
                ConcurrencyStamp = "a0e5628f-5ca7-4599-8d66-ee2782045d56"
            });
    }
}
