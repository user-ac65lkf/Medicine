

namespace Application.AppDTO
{
    public class ManufacturerDTO
    {
        public int ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }
        public string? ManufacturerAddress { get; set;}
        public CountryDTO ManufacturerCountry { get; set; } = null!;
    }
}
