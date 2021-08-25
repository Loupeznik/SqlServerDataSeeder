namespace SqlServerDataSeeder.Models
{
    public class OrderItems
    {
        public int OrderItemsID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }
    }
}
