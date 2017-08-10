using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DentalAssist.Models;

namespace DentalAssist.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170802205245_AddAspIdentity")]
    partial class AddAspIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DentalAssist.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int?>("DentistId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("DentistId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DentalAssist.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DentistId");

                    b.Property<string>("Description");

                    b.Property<int>("PatientId");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("AppointmentId");

                    b.HasIndex("DentistId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("DentalAssist.Models.DentalOperation", b =>
                {
                    b.Property<int>("DentalOperationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DentalOperationItemId");

                    b.Property<int>("DentistId");

                    b.Property<string>("Notes");

                    b.Property<int>("PatientId");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("StarDate");

                    b.Property<byte>("Status");

                    b.HasKey("DentalOperationId");

                    b.HasIndex("DentalOperationItemId");

                    b.HasIndex("DentistId");

                    b.HasIndex("PatientId");

                    b.ToTable("DentalOperation");
                });

            modelBuilder.Entity("DentalAssist.Models.DentalOperationItem", b =>
                {
                    b.Property<int>("DentalOperationItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("DentalOperationItemId");

                    b.ToTable("DentalOperationItem");
                });

            modelBuilder.Entity("DentalAssist.Models.DentalOperationTooth", b =>
                {
                    b.Property<int>("DentalOperationToothId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DentalOperationId");

                    b.Property<int>("ToothId");

                    b.HasKey("DentalOperationToothId");

                    b.HasIndex("DentalOperationId");

                    b.HasIndex("ToothId");

                    b.ToTable("DentalOperationTooth");
                });

            modelBuilder.Entity("DentalAssist.Models.Dentist", b =>
                {
                    b.Property<int>("DentistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("DentistId");

                    b.ToTable("Dentist");
                });

            modelBuilder.Entity("DentalAssist.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Notes");

                    b.Property<string>("Phone1");

                    b.Property<string>("Phone2");

                    b.Property<string>("SSN");

                    b.HasKey("PatientId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("DentalAssist.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DentalOperationId");

                    b.Property<string>("Notes");

                    b.Property<DateTime>("SessionDate");

                    b.HasKey("SessionId");

                    b.HasIndex("DentalOperationId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("DentalAssist.Models.Tooth", b =>
                {
                    b.Property<int>("ToothId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Index");

                    b.HasKey("ToothId");

                    b.ToTable("Tooth");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DentalAssist.Models.ApplicationUser", b =>
                {
                    b.HasOne("DentalAssist.Models.Dentist", "Dentist")
                        .WithMany()
                        .HasForeignKey("DentistId");
                });

            modelBuilder.Entity("DentalAssist.Models.Appointment", b =>
                {
                    b.HasOne("DentalAssist.Models.Dentist", "Dentist")
                        .WithMany("Appointments")
                        .HasForeignKey("DentistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DentalAssist.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DentalAssist.Models.DentalOperation", b =>
                {
                    b.HasOne("DentalAssist.Models.DentalOperationItem", "DentalOperationItem")
                        .WithMany("DentalOperations")
                        .HasForeignKey("DentalOperationItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DentalAssist.Models.Dentist", "Dentist")
                        .WithMany("DentalOperations")
                        .HasForeignKey("DentistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DentalAssist.Models.Patient", "Patient")
                        .WithMany("DentalOperations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DentalAssist.Models.DentalOperationTooth", b =>
                {
                    b.HasOne("DentalAssist.Models.DentalOperation", "DentalOperation")
                        .WithMany("DentalOperationTeeth")
                        .HasForeignKey("DentalOperationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DentalAssist.Models.Tooth", "Tooth")
                        .WithMany("DentalOperationTeeth")
                        .HasForeignKey("ToothId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DentalAssist.Models.Session", b =>
                {
                    b.HasOne("DentalAssist.Models.DentalOperation", "DentalOperation")
                        .WithMany("Sessions")
                        .HasForeignKey("DentalOperationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DentalAssist.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DentalAssist.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DentalAssist.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
