
using Application.Countries;
using Application.Doses;
using Application.Manufacturers;
using Application.Medforms;
using Application.Medicines;
using Application.Substances;
using Infrastructure.Persistance.MSSqlServer;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<DbContextMSSqlServer>(options => {
                options.UseSqlServer(conf.GetConnectionString("DefaultConn"));
            });
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<ISubstanceRepository, SubstanceRepository>();
            services.AddScoped<IDoseRepository, DoseRepository>();
            services.AddScoped<IMedformRepository, MedformRepository>();

            return services;
        }
    }
}
