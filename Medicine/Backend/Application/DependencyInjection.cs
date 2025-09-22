using Application.Countries;
using Application.Doses;
using Application.Manufacturers;
using Application.Medforms;
using Application.Medicines;
using Application.Substances;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {            
            services.AddScoped<ISubstanceServices, SubstanceServices>();
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddScoped<IManufacturerServices, ManufacturerServices>();
            services.AddScoped<IMedicineServices, MedicineServices>();
            services.AddScoped<IDoseServices, DoseServices>();
            services.AddScoped<IMedformServices, MedformServices>();
            //services.AddScoped<ILinqServices, LinqServices>();

            return services;
        }
    }
}
