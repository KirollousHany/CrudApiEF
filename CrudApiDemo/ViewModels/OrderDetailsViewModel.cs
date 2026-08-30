namespace CrudApiDemo.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }

        public List<OrderItemLine> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalItems { get; set; }
    }

    public class OrderItemLine
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
