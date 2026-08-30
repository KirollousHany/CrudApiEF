namespace CrudApiDemo.ViewModels
{
    public class ClientDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public List<ClientOrderSummary>? Orders { get; set; }
    }

    public class ClientOrderSummary
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal OrderTotal { get; set; }
        public int ItemCount { get; set; }
    }
}
