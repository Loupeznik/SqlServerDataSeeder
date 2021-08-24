namespace SqlServerDataSeeder.Models
{
    public class PaymentMethod : Entity
    {
        public int PaymentMethodID { get; set; }
        public int Type { get; set; }
        public bool IsValid { get; set; } = true;
        public string Name { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }
}
