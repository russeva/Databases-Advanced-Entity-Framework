namespace HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitationss { get; set; }
        public DbSet<Diagnose> Diagnose { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.FirstName)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode();

                entity.Property(e => e.LastName)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode();

                entity.Property(e => e.Address)
                       .HasMaxLength(250)
                       .IsUnicode();

                entity.Property(e => e.Email)
                        .IsRequired()
                        .IsUnicode(false)
                       .HasMaxLength(80);

                entity.Property(e => e.HasInsurance)
                      .HasDefaultValue(true);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(e => e.VisitationId);

                entity.Property(e => e.Date)
                      .HasColumnType("DATETIME2")
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Comments)
                      .HasMaxLength(250)
                      .IsUnicode();

            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(e => e.DiagnoseId);

                entity.Property(е => е.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);

                entity.Property(e => e.Comments)
                      .IsUnicode()
                      .HasMaxLength(250);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.MedicamentId);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(250);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pk => new
                {
                    pk.MedicamentId, pk.PatientId
                });

                entity.HasOne(e => e.Patient)
                      .WithMany(e => e.Prescriptions)
                      .HasForeignKey(e => e.PatientId);

                entity.HasOne(e => e.Medicament)
                      .WithMany(e => e.Prescriptions)
                      .HasForeignKey(e => e.MedicamentId);


            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.HasMany(e => e.Visitations)
                      .WithOne(e => e.Doctor);
                      
                      
            });
        }
    } 

}
