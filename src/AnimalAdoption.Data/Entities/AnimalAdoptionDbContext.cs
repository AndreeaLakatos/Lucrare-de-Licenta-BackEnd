using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnimalAdoption.Data.Entities
{
    public partial class AnimalAdoptionDbContext : IdentityDbContext<BasicUser>
    {
        public AnimalAdoptionDbContext(DbContextOptions<AnimalAdoptionDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<BasicUser> BasicUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserRoles());
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }
    }
}
