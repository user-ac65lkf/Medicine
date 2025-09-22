using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class DoseConfiguration : IEntityTypeConfiguration<Dose>
    {
        public void Configure(EntityTypeBuilder<Dose> builder)
        {
            builder.HasKey(c => c.Id);

            builder
           .HasData(
               new Dose() { Id = 1, Title = "мг", Dosage = 10 },
               new Dose() { Id = 2, Title = "мг", Dosage = 20 },
               new Dose() { Id = 3, Title = "мг", Dosage = 30 },
               new Dose() { Id = 4, Title = "мл", Dosage = 100 },
               new Dose() { Id = 5, Title = "мл", Dosage = 200 },
               new Dose() { Id = 6, Title = "мл", Dosage = 300 }
           );
        }
    }
}
