namespace SqlServerDataSeeder.Models
{
    public class Supplier : Entity
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
