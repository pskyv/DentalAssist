using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DentalAssist.Models;

namespace DentalAssist.Migrations
{
    [DbContext(typeof(DentalAssistContext))]
    partial class DentalAssistContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("DentistId");

                    b.Property<string>("Description");

                    b.Property<string>("Notes");

                    b.Property<int>("PatientId");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("StarDate");

                    b.Property<byte>("Status");

                    b.HasKey("DentalOperationId");

                    b.HasIndex("DentistId");

                    b.HasIndex("PatientId");

                    b.ToTable("DentalOperation");
                });

            modelBuilder.Entity("DentalAssist.Models.DentalOperationTooth", b =>
                {
                    b.Property<int>("DentalOperationId");

                    b.Property<int>("ToothId");

                    b.HasKey("DentalOperationId", "ToothId");

                    b.HasIndex("ToothId");

                    b.ToTable("DentalOperationTooth");
                });

            modelBuilder.Entity("DentalAssist.Models.Dentist", b =>
                {
                    b.Property<int>("DentistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

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
        }
    }
}
