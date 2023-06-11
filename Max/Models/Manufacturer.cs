namespace Max.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }


        public List<Processor> Processors { get; set; }
    }
}
