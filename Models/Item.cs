using System.Collections.Generic;

namespace SqlServerDataSeeder.Models
{
    public class Item : Entity
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool HasDiscount { get; set; } = false;
        public int Category { get; set; }
        public int InStock { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public string ImagePath { get; set; }
        public IList<OrderItems> OrderItems { get; set; }
    }
}
