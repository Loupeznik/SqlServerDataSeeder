using System.Collections.Generic;

namespace SqlServerDataSeeder.Models
{
    public class Client : Entity
    {
        public int ClientID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IList<Order>? Orders { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? PostalCode { get; set; }
        public int? PhoneNumber { get; set; }
        public IList<PaymentMethod>? PaymentMethods { get; set; }
    }
}
