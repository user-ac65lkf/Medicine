using Domain.Models;

namespace Application.Manufacturers
{
    public interface IManufacturerServices
    {
        Task<List<Manufacturer>> GetAllManufacturersAsync();

        Task<Manufacturer?> GetManufacturerByIdAsync(int id);

        Task<Manufacturer?> CreateManufacturerAsync(Manufacturer manufacturer);

        Task<bool> DeleteManufacturerAsync(int id);

        Task<bool> EditManufacturerAsync(Manufacturer manufacturer);
    }
}
