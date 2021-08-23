namespace SqlServerDataSeeder.Models
{
    public class User : Entity
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        public Client Client { get; set; }
    }
}
