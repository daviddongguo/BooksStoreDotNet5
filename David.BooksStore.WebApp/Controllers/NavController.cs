using David.BooksStore.Domain.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace David.BooksStore.WebApp.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository _rep;

        public NavController(IProductsRepository repo)
        {
            _rep = repo;
        }

        // Display the all categories in the sidebar
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = _rep
            .Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            return PartialView("FlexMenu", categories);
        }
    }
}
