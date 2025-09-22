using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(u => u.CountryName).IsUnique();

            builder
                .HasMany(c => c.Manufacturers)
                .WithOne(m => m.Country);

            builder
                .HasData(
                    new Country() { Id = 1, CountryName = "Uzbekistan" },
                    new Country() { Id = 2, CountryName = "Poland" },
                    new Country() { Id = 3, CountryName = "India" }
                );
        }
    }
}
