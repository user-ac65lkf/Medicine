using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class DoseMedicineConfiguration : IEntityTypeConfiguration<DoseMedicine>
    {
        public void Configure(EntityTypeBuilder<DoseMedicine> builder)
        {
            builder.HasKey(ms => new { ms.DoseId, ms.MedicineId });

            builder
            .HasData(
                new DoseMedicine() { MedicineId = 1, DoseId = 1 },
                new DoseMedicine() { MedicineId = 2, DoseId = 2 },
                new DoseMedicine() { MedicineId = 3, DoseId = 3 },
                new DoseMedicine() { MedicineId = 4, DoseId = 3 }
             );

        }
    }
}
