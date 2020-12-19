using David.BooksStore.Domain.Abstract;
using David.BooksStore.Domain.Entities;
using David.BooksStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace David.BooksStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _rep;
        private readonly int PAGE_SIZE = 5;

        public ProductController(IProductsRepository rep)
        {
            _rep = rep;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult OnGetPartial() => new PartialViewResult
        //{
        //    ViewName = "_ProductSummary",
        //    ViewData = ViewData,
        //};
        public IActionResult List(string category, int currentPage = 1)
        {
            ProductsListViewModel productsModel = new ProductsListViewModel
            {
                // Filter the products 
                Products = _rep
                        .Products
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.ProductId)
                        .Skip((currentPage - 1) * PAGE_SIZE)
                        .Take(PAGE_SIZE),

                // 
                PagingInfo = new PagingInfo
                {
                    CurrentPage = currentPage,
                    ItemsPerPage = PAGE_SIZE,
                    // Get the products remaind
                    TotalItems = _rep
                            .Products
                            .Where(p => category == null || p.Category == category)
                            .Count()
                },

                CurrentCategory = category
            };

            ViewBag.productsModel = productsModel;
            ViewBag.ReturnUrl = HttpContext.Request.Path + HttpContext.Request.QueryString;

            return View(productsModel);
        }


        public FileContentResult GetImage(int productId)
        {
            Product prod = _rep
                .Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
