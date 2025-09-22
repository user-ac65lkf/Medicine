
namespace Domain.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? CountryName { get; set; }
        public List<Manufacturer> Manufacturers { get; set; } = [];
    }
}
