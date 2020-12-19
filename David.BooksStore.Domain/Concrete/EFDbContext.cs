using David.BooksStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace David.BooksStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //  optionsBuilder.UseMySQL("server=bvakwjqxl1kivtlftlkl-mysql.services.clever-cloud.com;user id=uih9cosqpakteeln;pwd=cGaRGjCKajlUyz8fautM;persistsecurityinfo=True;database=bvakwjqxl1kivtlftlkl");
        //}
        public EFDbContext() : base()
        {
        }
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }
        // Declare a list
        public DbSet<Product> Products { get; set; }

       }
}
