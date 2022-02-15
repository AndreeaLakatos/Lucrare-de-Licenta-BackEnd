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
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserRoles());
        }
    }
}
