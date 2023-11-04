using LR8.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR8.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product { ID = 1, Name = "Product 1", Price = 10.99M, CreatedDate = DateTime.Now },
                new Product { ID = 2, Name = "Product 2", Price = 19.99M, CreatedDate = DateTime.Now },
                new Product { ID = 3, Name = "Product 3", Price = 25.50M, CreatedDate = DateTime.Now }
            };

            return View("Index", products);
        }
    }
}
