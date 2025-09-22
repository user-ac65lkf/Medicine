using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class MedformConfiguration : IEntityTypeConfiguration<Medform>
    {
        public void Configure(EntityTypeBuilder<Medform> builder)
        {
            builder.HasKey(m => m.Id);

            builder
            .HasData(
                new Medform() { Id = 1, Title = "Таблетки"},
                new Medform() { Id = 2, Title = "Раствор"},
                new Medform() { Id = 3, Title = "Капсула"},
                new Medform() { Id = 4, Title = "Капли"},
                new Medform() { Id = 5, Title = "Сироп"}
            );
        }
    }
}
