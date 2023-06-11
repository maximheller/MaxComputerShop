namespace Max.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
        public bool Paid { get; set; }

    }
}
