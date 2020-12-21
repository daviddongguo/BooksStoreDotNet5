using David.BooksStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace David.BooksStore.Domain.Abstract
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }

        Task<IQueryable<Product>> GetAllProducts();

        void SaveProduct(Product product);

        Product DeleteProduct(long productId);
    }
}
