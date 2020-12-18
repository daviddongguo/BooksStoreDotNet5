using System;
using David.BooksStore.Domain.Entities;

namespace David.BooksStore.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var p = CreateProduct();

            System.Console.WriteLine(p.ToString());

            Console.ReadKey();

        }

        private static object CreateProduct()
        {
            int i = 1;
            return new Product{
                Title = "Think in " + i,
                        Author = "J",
                        Price = 100 + i,
                        Category = (i % 4).ToString(),
                        Description = " " + i + " Great!"

            };
        }
    }
}
