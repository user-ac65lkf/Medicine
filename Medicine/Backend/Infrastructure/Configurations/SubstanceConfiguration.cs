using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class SubstanceConfiguration : IEntityTypeConfiguration<Substance>
    {
        public void Configure(EntityTypeBuilder<Substance> builder)
        {
            builder.HasKey(m => m.Id);

            builder
            .HasData(
                new Substance() { Id = 1, TradeName = "аланин", InternationalName = "аланин" },
                new Substance() { Id = 2, TradeName = "глицин", InternationalName = "глицин" },
                new Substance() { Id = 3, TradeName = "цетримид", InternationalName = "цетримид" },
                new Substance() { Id = 4, TradeName = "тофизопам", InternationalName = "тофизопам" },
                new Substance() { Id = 5, TradeName = "сорбитол", InternationalName = "сорбитол" }
            );
        }
    }
}
