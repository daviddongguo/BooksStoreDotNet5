using David.BooksStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace David.BooksStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }
        // Declare a list
        public DbSet<Product> Products { get; set; }

    }
}
