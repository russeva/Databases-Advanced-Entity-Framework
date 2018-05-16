using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalDatabase.Data.Models.Configuration
{
    class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(e => e.DiagnoseId);

            builder.Property(е => е.Name)
                  .IsRequired()
                  .IsUnicode()
                  .HasMaxLength(50);

            builder.Property(e => e.Comments)
                  .IsUnicode()
                  .HasMaxLength(250);
        }
    }
}
