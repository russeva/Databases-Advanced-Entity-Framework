using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalDatabase.Data.Models.Configuration
{
    class VisitationConfiguration : IEntityTypeConfiguration<Visitation>
    {
        public void Configure(EntityTypeBuilder<Visitation> builder)
        {
            builder.HasKey(e => e.VisitationId);

            builder.Property(e => e.Date)
                  .HasColumnType("DATETIME2")
                  .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.Comments)
                  .HasMaxLength(250)
                  .IsUnicode();

        }
    }
}
