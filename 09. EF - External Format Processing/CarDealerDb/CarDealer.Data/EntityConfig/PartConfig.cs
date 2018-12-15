namespace CarDealer.Data.EntityConfig
{
    using System;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartConfig : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Parts)
                .HasForeignKey(x => x.SupplierId);

            
        }
    }
}
