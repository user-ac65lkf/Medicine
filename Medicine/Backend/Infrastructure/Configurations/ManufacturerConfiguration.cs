using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasIndex(u => u.ManufacturerName).IsUnique();

            builder
                .HasOne(m => m.Country)
                .WithMany(c => c.Manufacturers)
                .HasForeignKey(m => m.CountryId);

            builder
                .HasData(
                    new Manufacturer() { Id = 1, ManufacturerName = "NikaPharm", ManufacturerAddress = "Address, address", CountryId = 1},
                    new Manufacturer() { Id = 2, ManufacturerName = "Gedeon", ManufacturerAddress = "Address, address", CountryId= 2},
                    new Manufacturer() { Id = 3, ManufacturerName = "GSK", ManufacturerAddress = "Address, address", CountryId= 3},
                    new Manufacturer() { Id = 4, ManufacturerName = "Novartis", ManufacturerAddress = "Address, address", CountryId = 3 }
                );
        }
    }
}
