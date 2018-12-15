namespace CarDealer.Data.EntityConfig
{
    using System;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Make)
                .IsRequired();

            builder.Property(x => x.Model)
                .IsRequired();
        }
    }
}
