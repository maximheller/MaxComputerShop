using System.ComponentModel.DataAnnotations.Schema;

namespace Max.Models
{
    public class Processor : Product
    {      
            public double Frequency { get; set; }
            public string? ImageFileName { get; set; }

            [NotMapped]
            public IFormFile ImageFormFile { get; set; }

            public int ManufacturerId { get; set; } //foreign key
            public Manufacturer Manufacturer { get; set; }

            public virtual ICollection<Category> Categories { get; set; }

            //public ICollection<CategoryProcessor> ProcessorCategories { get; set; }

    }
}
