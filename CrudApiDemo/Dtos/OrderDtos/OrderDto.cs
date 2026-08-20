namespace CrudApiDemo.Dtos.OrderDtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
