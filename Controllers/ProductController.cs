using ASP_MVC_PROJ.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_PROJ.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product { ID = 1, Name = "Product 1", Price = 10.99M },
                new Product { ID = 2, Name = "Product 2", Price = 19.99M },
                new Product { ID = 3, Name = "Product 3", Price = 5.99M },
                new Product { ID = 4, Name = "Product 4", Price = 14.99M }
            };

            return View(products);
        }
    }
}
