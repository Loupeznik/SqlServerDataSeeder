using System;
using System.Collections.Generic;

namespace SqlServerDataSeeder.Models
{
    public class Order : Entity
    {
        public int OrderID { get; set; }
        public IList<OrderItems> OrderItems { get; set; }
        public double Total { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
        public int Status { get; set; }
        public DateTime ShippedAt { get; set; }
        public DateTime PaidAt { get; set; }
        public int Shipping { get; set; }
    }
}
