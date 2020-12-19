using David.BooksStore.Domain.Concrete;
using David.BooksStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace David.BooksStore.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var p = CreateProduct();
            //System.Console.WriteLine(p.ToString());
            //InsertData();
            PrintData(args[0]);


            Console.ReadKey();

        }

        private static void PrintData(string connectionString)
        {
            var options = new DbContextOptionsBuilder<EFDbContext>()
                        .UseMySQL(connectionString)
                        .Options;

            using var context = new EFDbContext(options);
            var products = context.Products;
            foreach (var p in products)
            {
                Console.WriteLine(p.ToString());
            }

        }
        //private static void InsertData()
        //{
        //    using var context = new EFDbContext();
        //    // Creates the database if not exists
        //    context.Database.EnsureCreated();

        //    // Adds a product
        //    for(int i = 3; i <= 51; i++)
        //    {               
        //        context.Products.Add(CreateProduct(i));
        //    }
        //    // Saves changes
        //    context.SaveChanges();
        //}

        private static Product CreateProduct(int i)
        {
            return new Product
            {
                Title = "Think in " + i,
                Author = "J",
                Price = 100 + i,
                Category = (i % 4).ToString(),
                Description = " " + i + " Great!"

            };
        }
    }
}
