
namespace Domain.Models
{
    public class DoseMedicine
    {
        public int DoseId { get; set; }
        public Dose Dose { get; set; } = null!;
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
    }
}
