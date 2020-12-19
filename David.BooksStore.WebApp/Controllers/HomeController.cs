using David.BooksStore.Domain.Abstract;
using David.BooksStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace David.BooksStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsRepository _rep;

        public HomeController(ILogger<HomeController> logger, IProductsRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult Index()
        {
            //using var context = new EFDbContext();
            var product = _rep.Products.FirstOrDefault();
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
