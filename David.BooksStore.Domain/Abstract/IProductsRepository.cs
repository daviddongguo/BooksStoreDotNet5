using David.BooksStore.Domain.Entities;
using System.Collections.Generic;

namespace David.BooksStore.Domain.Abstract
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(long productId);
    }
}
