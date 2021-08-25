namespace SqlServerDataSeeder.Models
{
    public class Payment : Entity
    {
        public int PaymentID { get; set; }
        public int PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int? OrderID { get; set; }
        public Order? Order { get; set; }
    }
}
