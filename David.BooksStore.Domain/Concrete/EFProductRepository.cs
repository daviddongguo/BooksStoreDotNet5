using David.BooksStore.Domain.Abstract;
using David.BooksStore.Domain.Entities;
using System.Collections.Generic;

namespace David.BooksStore.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {

        private EFDbContext _ctx = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return _ctx.Products; }
        }

        public Product DeleteProduct(int productId)
        {
            Product dbProduct = _ctx.Products.Find(productId);
            if (dbProduct == null)
            {
                return null;
            }
            _ctx.Products.Remove(dbProduct);
            _ctx.SaveChanges();
            return dbProduct;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)  // a new product
            {
                _ctx.Products.Add(product);
            }
            else                   // an old product whose productId is exists
            {
                Product dbProduct = _ctx.Products.Find(product.ProductId);
                if (dbProduct == null)
                {
                    return;
                }

                dbProduct.Title = product.Title;
                dbProduct.Description = product.Description;
                dbProduct.Author = product.Author;
                dbProduct.Price = product.Price;
                dbProduct.Category = product.Category;
                dbProduct.ImageData = product.ImageData;
                dbProduct.ImageMimeType = product.ImageMimeType;
            }
            _ctx.SaveChanges();
        }
    }
}
