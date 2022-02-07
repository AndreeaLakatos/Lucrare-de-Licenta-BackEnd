using Microsoft.EntityFrameworkCore;

namespace AnimalAdoption.Data.Entities
{
    public partial class AnimalAdoptionDbContext : DbContext
    {
        public AnimalAdoptionDbContext()
        {
        }

        public AnimalAdoptionDbContext(DbContextOptions<AnimalAdoptionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Ong> Ong { get; set; }
    }
}
