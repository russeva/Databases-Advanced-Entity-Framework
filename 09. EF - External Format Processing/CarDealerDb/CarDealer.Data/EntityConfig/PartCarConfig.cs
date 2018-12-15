namespace CarDealer.Data.EntityConfig
{
    using System;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartCarConfig : IEntityTypeConfiguration<PartCars>
    {
        public void Configure(EntityTypeBuilder<PartCars> builder)
        {
            builder.HasKey(x => new { x.CarId, x.PartId});

            builder.HasOne(x => x.Car)
                .WithMany(x => x.Parts)
                .HasForeignKey(x => x.CarId);

            builder.HasOne(x => x.Part)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.PartId);
        }
    }
}
