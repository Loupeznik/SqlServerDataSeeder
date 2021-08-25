using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Faker;
using SqlServerDataSeeder.Data;
using SqlServerDataSeeder.Models;

namespace SqlServerDataSeeder
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            await using var dataContext = new DataContext();

            Console.WriteLine("Preparing records");
            
            var users = GenerateClientsWithAccounts();
            var orders = GenerateOrders();
            var items = GenerateItems();
            var orderItems = GenerateOrderItems();

            await dataContext.AddRangeAsync(users);
            await dataContext.AddRangeAsync(orders);
            await dataContext.AddRangeAsync(items);
            await dataContext.AddRangeAsync(orderItems);

            Console.WriteLine("Seeding records");
            
            await dataContext.SaveChangesAsync();
        }

        private static List<User> GenerateClientsWithAccounts()
        {
            Console.WriteLine("Creating clients with user accounts");
            var users = new List<User>();

            for (var x = 0; x < 1000000; x++)
            {
                if (x % 100000 == 0 && x != 0)
                {
                    Console.WriteLine($"Processed {x} out of {1000000}");
                }
                
                users.Add(new User
                {
                    Client = new Client
                    {
                        Address = Address.StreetAddress(),
                        City = Address.City(),
                        FirstName = Name.First(),
                        LastName = Name.Last(),
                        PhoneNumber = 123123123,
                        PostalCode = 75531
                    },
                    Email = Internet.Email(),
                    Username = Internet.UserName(),
                    Password = Convert.ToBase64String(new byte[256])
                });
            }

            Console.WriteLine("Done");
            return users;
        }

        private static List<Item> GenerateItems()
        {
            Console.WriteLine("Creating items");
            
            var items = new List<Item>();

            for (var x = 0; x < 2000000; x++)
            {
                if (x % 100000 == 0 && x != 0)
                {
                    Console.WriteLine($"Processed {x} out of {2000000}");
                }
                
                items.Add(new Item
                {
                    Category = RandomNumber.Next(10),
                    HasDiscount = Faker.Boolean.Random(),
                    ImagePath = Internet.SecureUrl(),
                    InStock = RandomNumber.Next(1000, 5000000),
                    Name = Lorem.GetFirstWord(),
                    Supplier = new Supplier
                    {
                        Address = Address.StreetAddress() + " " + Address.City() + " " + Address.Country(),
                        Name = Company.Name()
                    },
                    Price = new Random().NextDouble()
                });
            }

            Console.WriteLine("Done");
            return items;
        }

        private static List<Order> GenerateOrders()
        {
            Console.WriteLine("Creating orders");
            
            var orders = new List<Order>();

            for (var x = 0; x < 500000; x++)
            {
                if (x % 100000 == 0 && x != 0)
                {
                    Console.WriteLine($"Processed {x} out of {5000000}");
                }
                
                var clientId = RandomNumber.Next(1, 1000000);
                
                orders.Add(new Order
                {
                    ClientID = clientId,
                    PaidAt = DateTime.Now - TimeSpan.FromHours(RandomNumber.Next(1, 10000)),
                    ShippedAt = DateTime.Now - TimeSpan.FromHours(RandomNumber.Next(1, 10000)),
                    Shipping = RandomNumber.Next(1, 10),
                    Payment = new Payment
                    {
                        PaymentMethod = new PaymentMethod
                        {
                            ClientID = clientId,
                            Name = "random",
                            IsValid = true,
                            Type = RandomNumber.Next(1, 4)
                        },
                        Status = RandomNumber.Next(1, 3),
                        Type = RandomNumber.Next(1, 5)
                    },
                    Status = RandomNumber.Next(1, 3)
                });
            }

            Console.WriteLine("Done");
            return orders;
        }

        private static List<OrderItems> GenerateOrderItems()
        {
            Console.WriteLine("Creating order items");
            
            var orderItems = new List<OrderItems>();

            for (var x = 0; x < 500000; x++)
            {
                if (x % 100000 == 0 && x != 0)
                {
                    Console.WriteLine($"Processed {x} out of {500000}");
                }
                
                var orderId = RandomNumber.Next(1, 500000);
                for (var y = 0; y < 2; y++)
                {
                    orderItems.Add(new OrderItems
                    {
                        OrderID = orderId,
                        ItemID = RandomNumber.Next(1, 2000000),
                        Count = RandomNumber.Next()
                    });
                }
            }

            Console.WriteLine("Done");
            return orderItems;
        }
    }
}
