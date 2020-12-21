using David.BooksStore.Domain.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace David.BooksStore.WebApp.ViewComponents
{
    [ViewComponent(Name = "NavMenu")]
    public class NavViewComponent : ViewComponent
    {
        private IProductsRepository _rep;

        public NavViewComponent(IProductsRepository repo)
        {
            _rep = repo;
        }

        // Display the all categories in the sidebar
        public async Task<IViewComponentResult> InvokeAsync(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var products = await _rep.GetAllProducts();
            IEnumerable<string> categories = products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            return View("FlexMenu", categories);
        }
    }
}
