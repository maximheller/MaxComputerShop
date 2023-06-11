namespace Max.Models.viewModels
{
    public class RamViewModel
    {
        public string Name { get; set; }
        public decimal MemoryCapacity { get; set; }
        public double Frequency { get; set; }
        public string Description { get; set; }
        
        public IFormFile ImageFormFile { get; set; }

    }
}
