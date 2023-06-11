using System.ComponentModel.DataAnnotations.Schema;

namespace Max.Models
{
    public class Ram : Product
    {
        public decimal MemoryCapacity { get; set; }
        public double Frequency { get; set; }
        public string? ImageFileName { get; set; }

        [NotMapped]
        public IFormFile ImageFormFile { get; set; }
        public int ManufacturerId { get; set; } //foreign key
        public Manufacturer Manufacturer { get; set; }
    }
}
