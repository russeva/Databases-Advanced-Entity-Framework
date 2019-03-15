namespace PetClinic.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Models;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext() { }

        public PetClinicContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalAid> AnimalAids { get; set; }

        public DbSet<Passport> Passprts { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<ProcedureAnimalAid> ProcedureAnimalAid { get; set; }

        public DbSet<Vet> Vets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>()
                .HasMany(a => a.Procedures)
                .WithOne(a => a.Animal)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AnimalAid>()
                .HasMany(aa => aa.AnimalAidProcedures)
                .WithOne(aa => aa.AnimalAid)
                .HasForeignKey(aa => aa.AnimalAidId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AnimalAid>()
                .HasAlternateKey(aa => aa.Name);

            builder.Entity<Procedure>()
                .HasMany(p => p.ProcedureAnimalAids)
                .WithOne(p => p.Procedure)
                .HasForeignKey(p => p.ProcedureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProcedureAnimalAid>()
                .HasKey(pp => new { pp.ProcedureId, pp.AnimalAidId });

            builder.Entity<Vet>()
                .HasMany(v => v.Procedures)
                .WithOne(v => v.Vet)
                .HasForeignKey(v => v.VetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
