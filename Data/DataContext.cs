using Microsoft.EntityFrameworkCore;
using SqlServerDataSeeder.Models;

namespace SqlServerDataSeeder.Data
{
    public class DataContext : DbContext
    {
        private static readonly DbConnectionHelper Helpers = new();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helpers.GetConnectionString());
        }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>()
                .HasOne(x => x.User)
                .WithOne(x => x.Client)
                .HasForeignKey<Client>(x => x.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Client>()
                .HasMany<Order>(x => x.Orders)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Client>()
                .HasMany<PaymentMethod>(x => x.PaymentMethods)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Item>()
                .HasOne(x => x.Supplier)
                .WithMany()
                .HasForeignKey(x => x.SupplierID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderItems>()
                .HasOne(x => x.Item)
                .WithMany()
                .HasForeignKey(x => x.ItemID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<OrderItems>()
                .HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(x => x.Order)
                .WithOne(x => x.Payment)
                .HasForeignKey<Payment>(x => x.OrderID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Payment>()
                .HasOne(x => x.PaymentMethod)
                .WithMany()
                .HasForeignKey(x => x.PaymentMethodID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

