using System.ComponentModel.DataAnnotations.Schema;

namespace Max.Models.viewModels
{
    public class RamCreateViewModel
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public decimal MemoryCapacity { get; set; }
        public double Frequency { get; set; }          
        public int ManufacturerId { get; set; } 
        
    }
}
