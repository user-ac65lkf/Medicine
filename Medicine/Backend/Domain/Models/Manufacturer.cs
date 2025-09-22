using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string? ManufacturerName { get; set; }
        public string? ManufacturerAddress { get; set; }
        public List<Medicine> Medicine { get; set; } = [];
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
    }
}
