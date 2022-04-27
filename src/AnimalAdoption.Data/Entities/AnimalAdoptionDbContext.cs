﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalAdoption.Data.Entities
{
    public partial class AnimalAdoptionDbContext : IdentityDbContext<BasicUser>
    {
        public AnimalAdoptionDbContext(DbContextOptions<AnimalAdoptionDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<BasicUser> BasicUsers { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<AdoptionAnnouncement> AdoptionAnnouncements { get; set; } 
        public virtual DbSet<User> AppUsers { get; set; }
        public virtual DbSet<UserPreferences> UserPreferencess { get; set; }
        public virtual DbSet<FosterApplication> FosterApplications { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Ngo> Ngos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserRoles());
        }
    }
}
