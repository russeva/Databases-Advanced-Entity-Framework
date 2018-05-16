using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalDatabase.Data.Models.Configuration
{
    class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.PatientId);

            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.Property(e => e.Address)
                   .HasMaxLength(250)
                   .IsUnicode();

            builder.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false)
                   .HasMaxLength(80);

            builder.Property(e => e.HasInsurance)
                  .HasDefaultValue(true);
        }
    }
}
