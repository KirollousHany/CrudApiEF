namespace CrudApiDemo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
