using System.ComponentModel.DataAnnotations.Schema;

namespace Max.Models.viewModels
{
    public class ProcessorCreateViewModel
    {
        public double Frequency { get; set; }      

        public int ManufacturerId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


    }
}
