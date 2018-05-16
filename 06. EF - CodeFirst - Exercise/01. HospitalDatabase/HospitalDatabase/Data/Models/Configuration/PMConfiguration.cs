using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalDatabase.Data.Models.Configuration
{
    class PMConfiguration : IEntityTypeConfiguration<PatientMedicament>
    {
        public void Configure(EntityTypeBuilder<PatientMedicament> builder)
        {
            builder.HasKey(pk => new
            {
                pk.MedicamentId,
                pk.PatientId
            });

            builder.HasOne(e => e.Patient)
                  .WithMany(e => e.Prescriptions)
                  .HasForeignKey(e => e.PatientId);

            builder.HasOne(e => e.Medicament)
                  .WithMany(e => e.Prescriptions)
                  .HasForeignKey(e => e.MedicamentId);

        }
    }
}
