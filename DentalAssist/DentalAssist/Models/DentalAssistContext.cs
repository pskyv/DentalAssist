using Microsoft.EntityFrameworkCore;

namespace DentalAssist.Models
{
    public class DentalAssistContext : DbContext
    {
        public DentalAssistContext(DbContextOptions<DentalAssistContext> options) : base(options) { }
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<DentalOperation> DentalOperations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Tooth> Teeth { get; set; }
        public DbSet<DentalOperationTooth> DentalOperationTeeth { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Dentist>().ToTable("Dentist");
            modelBuilder.Entity<DentalOperation>().ToTable("DentalOperation");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Session>().ToTable("Session");
            modelBuilder.Entity<Tooth>().ToTable("Tooth");
            modelBuilder.Entity<DentalOperationTooth>().ToTable("DentalOperationTooth");

            modelBuilder.Entity<Patient>().Ignore(p => p.FullName);
            modelBuilder.Entity<Dentist>().Ignore(d => d.FullName);

            modelBuilder.Entity<DentalOperation>()
                .HasOne(d => d.Patient)
                .WithMany(p => p.DentalOperations);

            modelBuilder.Entity<DentalOperation>()
                .HasOne(d => d.Dentist)
                .WithMany(p => p.DentalOperations);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.DentalOperation)
                .WithMany(d => d.Sessions);

            modelBuilder.Entity<DentalOperationTooth>()
            .HasKey(d => new { d.DentalOperationId, d.ToothId });

            modelBuilder.Entity<DentalOperationTooth>()
                .HasOne(dt => dt.DentalOperation)
                .WithMany(t => t.DentalOperationTeeth)
                .HasForeignKey(dt => dt.DentalOperationId);

            modelBuilder.Entity<DentalOperationTooth>()
                .HasOne(dt => dt.Tooth)
                .WithMany(t => t.DentalOperationTeeth)
                .HasForeignKey(dt => dt.ToothId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Dentist)
                .WithMany(d => d.Appointments);
        }
    }
}
