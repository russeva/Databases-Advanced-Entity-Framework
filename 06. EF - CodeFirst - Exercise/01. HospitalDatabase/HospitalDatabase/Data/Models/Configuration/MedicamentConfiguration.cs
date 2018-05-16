using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalDatabase.Data.Models.Configuration
{
    class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.MedicamentId);

            builder.Property(e => e.Name)
                  .IsRequired()
                  .IsUnicode()
                  .HasMaxLength(250);
        }
    }
}
