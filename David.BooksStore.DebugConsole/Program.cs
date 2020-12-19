using David.BooksStore.Domain.Concrete;
using David.BooksStore.Domain.Entities;
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
            InsertData();
            PrintData();

            Console.ReadKey();

        }

        // private static void PrintData()
        // {
        //     using var context = new EFDbContext();
        //     var products = context.Products;
        //     foreach (var p in products)
        //     {
        //         Console.WriteLine(p.ToString());
        //     }

        // }
        // private static void InsertData()
        // {
        //     using var context = new EFDbContext();
        //     // Creates the database if not exists
        //     context.Database.EnsureCreated();

        //     // Adds a product
        //     var product = CreateProduct();
        //     context.Products.Add(product);

        //     // Saves changes
        //     context.SaveChanges();
        // }

        private static Product CreateProduct()
        {
            int i = 2;
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
