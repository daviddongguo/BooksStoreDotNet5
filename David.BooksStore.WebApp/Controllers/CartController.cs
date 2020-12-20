using David.BooksStore.Domain.Abstract;
using David.BooksStore.Domain.Entities;
using David.BooksStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace David.BooksStore.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository _rep;
        //private readonly IOrderProcessor _orderProcessor;

        public CartController(IProductsRepository repo)
        {
            _rep = repo;
            //_orderProcessor = proc;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public IActionResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _rep.Products
            .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _rep.Products
            .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }



        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                //_orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Completed()
        {
            return View();
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}
