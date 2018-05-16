namespace HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using HospitalDatabase.Data.Models;
    using HospitalDatabase.Data.Models.Configuration;

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
            modelBuilder.ApplyConfiguration(new PatientConfiguration());

            modelBuilder.ApplyConfiguration(new VisitationConfiguration());

            modelBuilder.ApplyConfiguration(new DiagnoseConfiguration());

            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());

            modelBuilder.ApplyConfiguration(new PMConfiguration());

            modelBuilder.ApplyConfiguration(new DoctorConfiguration());

        }
    } 

}
