using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class MedicineSubstanceConfiguration : IEntityTypeConfiguration<MedicineSubstance>
    {
        public void Configure(EntityTypeBuilder<MedicineSubstance> builder)
        {
            builder.HasKey(ms => new {ms.MedicineId, ms.SubstanceId});

            builder
            .HasData(
                new MedicineSubstance() { MedicineId = 1, SubstanceId = 1 },
                new MedicineSubstance() { MedicineId = 2, SubstanceId = 2 },
                new MedicineSubstance() { MedicineId = 3, SubstanceId = 3 },
                new MedicineSubstance() { MedicineId = 4, SubstanceId = 3 }
             );

        }
    }
}
