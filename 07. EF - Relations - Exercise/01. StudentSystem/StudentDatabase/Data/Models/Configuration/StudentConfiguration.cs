﻿namespace StudentDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            builder.Property(s => s.PhoneNumber)
                   .IsRequired(false)
                   .IsUnicode(false)
                   .HasColumnType("CHAR(10)");

            builder.Property(s => s.RegisteredOn)
                   .HasColumnType("DATETIME2")
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(s => s.Birthday)
                   .IsRequired(false);
        }
    }
}
