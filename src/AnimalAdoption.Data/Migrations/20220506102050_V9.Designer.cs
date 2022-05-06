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
    [Migration("20220506102050_V9")]
    partial class V9
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

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NgoId");

                    b.ToTable("AdoptionAnnouncements");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.AdoptionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdoptionAnnouncementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AvailableDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BasicUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SomethingElse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AdoptionAnnouncementId");

                    b.HasIndex("BasicUserId");

                    b.ToTable("AdoptionRequests");
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

            modelBuilder.Entity("AnimalAdoption.Data.Entities.FosteringAnnouncement", b =>
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

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MoreDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NgoId");

                    b.ToTable("FosteringAnnouncements");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.FosteringRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AvailableDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BasicUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FosteringAnnouncementId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SomethingElse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BasicUserId");

                    b.HasIndex("FosteringAnnouncementId");

                    b.ToTable("FosteringRequests");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdoptionAnnouncementId")
                        .HasColumnType("int");

                    b.Property<int?>("FosteringAnnouncementId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdoptionAnnouncementId");

                    b.HasIndex("FosteringAnnouncementId");

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
                            Id = "9aa076f1-fbbe-4cde-9329-0e91391c8e3e",
                            ConcurrencyStamp = "684ab5ea-4c5a-430a-bf0b-ba93f006b4da",
                            Name = "BasicUser",
                            NormalizedName = "BASICUSER"
                        },
                        new
                        {
                            Id = "458f8460-109d-40ec-94d5-54dd6b637595",
                            ConcurrencyStamp = "ea8d442e-91c0-498d-8984-f11264ff58d9",
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

            modelBuilder.Entity("AnimalAdoption.Data.Entities.AdoptionRequest", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.AdoptionAnnouncement", null)
                        .WithMany("AdoptionRequests")
                        .HasForeignKey("AdoptionAnnouncementId");

                    b.HasOne("AnimalAdoption.Data.Entities.BasicUser", null)
                        .WithMany("AdoptionRequests")
                        .HasForeignKey("BasicUserId");
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

            modelBuilder.Entity("AnimalAdoption.Data.Entities.FosteringAnnouncement", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.Ngo", null)
                        .WithMany("FosteringAnnouncements")
                        .HasForeignKey("NgoId");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.FosteringRequest", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.BasicUser", null)
                        .WithMany("FosteringRequests")
                        .HasForeignKey("BasicUserId");

                    b.HasOne("AnimalAdoption.Data.Entities.FosteringAnnouncement", null)
                        .WithMany("FosteringRequests")
                        .HasForeignKey("FosteringAnnouncementId");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Photo", b =>
                {
                    b.HasOne("AnimalAdoption.Data.Entities.AdoptionAnnouncement", null)
                        .WithMany("Photos")
                        .HasForeignKey("AdoptionAnnouncementId");

                    b.HasOne("AnimalAdoption.Data.Entities.FosteringAnnouncement", null)
                        .WithMany("Photos")
                        .HasForeignKey("FosteringAnnouncementId");
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
                    b.Navigation("AdoptionRequests");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.BasicUser", b =>
                {
                    b.Navigation("AdoptionRequests");

                    b.Navigation("FosteringRequests");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.FosteringAnnouncement", b =>
                {
                    b.Navigation("FosteringRequests");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("AnimalAdoption.Data.Entities.Ngo", b =>
                {
                    b.Navigation("AdoptionAnnouncements");

                    b.Navigation("FosteringAnnouncements");
                });
#pragma warning restore 612, 618
        }
    }
}
