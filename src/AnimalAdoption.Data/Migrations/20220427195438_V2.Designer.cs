﻿// <auto-generated />
using System;
using AnimalAdoption.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalAdoption.Data.Migrations
{
    [DbContext(typeof(AnimalAdoptionDbContext))]
    [Migration("20220427195438_V2")]
    partial class V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountyId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.AdoptionAnnouncement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalSize")
                        .HasColumnType("int");

                    b.Property<int>("AnimalType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoreDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NgoId");

                    b.ToTable("AdoptionAnnouncements");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalSize")
                        .HasColumnType("int");

                    b.Property<int>("AnimalType")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NgoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NgoId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.BasicUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BasicUser");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.FosterApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAdopted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.ToTable("FosterApplications");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdoptionAnnouncementId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdoptionAnnouncementId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.UserPreferences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalSize")
                        .HasColumnType("int");

                    b.Property<int>("AnimalType")
                        .HasColumnType("int");

                    b.Property<bool>("HasChildren")
                        .HasColumnType("bit");

                    b.Property<bool>("HasFamily")
                        .HasColumnType("bit");

                    b.Property<string>("LivingPlace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserPreferencess");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "7bcc9ecb-bf3e-4813-bc17-896b761ac8da",
                            ConcurrencyStamp = "39821b48-061b-40c2-b372-c42961c7fc8a",
                            Name = "BasicUser",
                            NormalizedName = "BASICUSER"
                        },
                        new
                        {
                            Id = "6d205a51-c2b7-4ebf-8c4f-27167188a5c6",
                            ConcurrencyStamp = "62de60cc-6d46-4732-a6c2-ad9fde5c9c2c",
                            Name = "Ngo",
                            NormalizedName = "NGO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Ngo", b =>
                {
                    b.HasBaseType("AnimalAdoption.Data.Entities.BasicUser");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FoundedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NgoAddressId")
                        .HasColumnType("int");

                    b.Property<string>("NgoName")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("NgoAddressId");

                    b.HasDiscriminator().HasValue("Ngo");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.User", b =>
                {
                    b.HasBaseType("AnimalAdoption.Data.Entities.BasicUser");

                    b.Property<int?>("UserPreferencesId")
                        .HasColumnType("int");

                    b.HasIndex("UserPreferencesId");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Address", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("AnimalAdoption.Data.Entities.County", "County")
                        .WithMany()
                        .HasForeignKey("CountyId");

                    b.Navigation("City");

                    b.Navigation("County");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.AdoptionAnnouncement", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.Ngo", null)
                        .WithMany("AdoptionAnnouncements")
                        .HasForeignKey("NgoId");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Advertisement", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId");

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Animal", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.Ngo", "Ngo")
                        .WithMany()
                        .HasForeignKey("NgoId");

                    b.Navigation("Ngo");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.BasicUser", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.City", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.County", "County")
                        .WithMany()
                        .HasForeignKey("CountyId");

                    b.Navigation("County");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.FosterApplication", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.Advertisement", null)
                        .WithMany("FosterApplication")
                        .HasForeignKey("AdvertisementId");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Photo", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.AdoptionAnnouncement", null)
                        .WithMany("Images")
                        .HasForeignKey("AdoptionAnnouncementId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.BasicUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.BasicUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalAdoption.Data.Entities.BasicUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.BasicUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Ngo", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.Address", "NgoAddress")
                        .WithMany()
                        .HasForeignKey("NgoAddressId");

                    b.Navigation("NgoAddress");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.User", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.UserPreferences", "UserPreferences")
                        .WithMany()
                        .HasForeignKey("UserPreferencesId");

                    b.Navigation("UserPreferences");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.AdoptionAnnouncement", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Advertisement", b =>
                {
                    b.Navigation("FosterApplication");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Ngo", b =>
                {
                    b.Navigation("AdoptionAnnouncements");
                });
#pragma warning restore 612, 618
        }
    }
}