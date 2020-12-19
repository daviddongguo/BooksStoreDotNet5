using David.BooksStore.Domain.Abstract;
using David.BooksStore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace David.BooksStore.WebApp.Areas.Admin.Controllers
{
    // [Authorize]
    [Area("Products")]
    public class AdminController : Controller
    {
        private readonly IProductsRepository _rep;

        public AdminController(IProductsRepository repo)
        {
            _rep = repo;
        }

        public ViewResult Index()
        {
            return View(_rep.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = _rep
            .Products
            .FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, IFormFile image = null)
        {
            if (ModelState.IsValid)
            {
                if (image.Length > 0)
                {
                    product.ImageMimeType = image.ContentType;

                    // Convert image to byte and save to database
                    byte[] fileBytes = null;
                    using var fileStream = image.OpenReadStream();
                    using var memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    fileBytes = memoryStream.ToArray();

                    product.ImageData = fileBytes;
                }

                _rep.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }


        [HttpPost]
        public ActionResult Delete(long productId)
        {
            Product deletedProduct = _rep.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format($"{deletedProduct.Title} was selected");
            }

            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(long productId)
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
