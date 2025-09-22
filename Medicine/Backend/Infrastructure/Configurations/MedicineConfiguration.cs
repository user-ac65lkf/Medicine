using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(m => m.Id);

            builder
            .HasData(
                new Medicine() { Id = 1, TradeName = "Экватор", InterName = "Ekvator", ManufacturerId = 1, MedformId = 2, ImageUrl= "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg" },
                new Medicine() { Id = 2, TradeName = "Парацетамол", InterName = "Paracetamol", ManufacturerId = 2, MedformId = 1, ImageUrl = "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg" },
                new Medicine() { Id = 3, TradeName = "Тримол", InterName = "Trimol", ManufacturerId = 1, MedformId = 2, ImageUrl = "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg" },
                new Medicine() { Id = 4, TradeName = "Аквад", InterName = "Acvad", ManufacturerId = 1, MedformId = 2, ImageUrl = "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg" }

            );
        }
    }
}
