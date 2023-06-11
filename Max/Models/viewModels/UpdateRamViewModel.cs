namespace Max.Models.viewModels
{
    public class UpateRamViewModel
    {       

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MemoryCapacity { get; set; }
        public double Frequency { get; set; }
        public string Description { get; set; }
        
        public IFormFile ImageFormFile { get; set; }


        public int ManufacturerId { get; set; }
    }
}
