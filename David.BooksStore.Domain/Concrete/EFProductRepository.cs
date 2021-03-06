﻿using David.BooksStore.Domain.Abstract;
using David.BooksStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace David.BooksStore.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {

        private EFDbContext _ctx;

        public EFProductRepository(EFDbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public IEnumerable<Product> Products
        {
            get { return _ctx.Products; }
        }

        public async Task<IQueryable<Product>> GetAllProducts() 
        {
            return (await _ctx.Products.ToListAsync()).AsQueryable();
        }
        public Product DeleteProduct(long productId)
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
