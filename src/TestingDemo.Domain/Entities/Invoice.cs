namespace TestingDemo.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
    }
}