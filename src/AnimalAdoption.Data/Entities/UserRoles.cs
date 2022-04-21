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
                Name = "BasicUser",
                NormalizedName = "BASICUSER"
            },
            new IdentityRole
            {
                Name = "Ngo",
                NormalizedName = "NGO"
            });
    }
}
