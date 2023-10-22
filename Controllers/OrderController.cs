using Microsoft.AspNetCore.Mvc;
using ASP_MVC_PROJ.Models;
using System.Collections.Generic;

namespace ASP_MVC_PROJ.Controllers
{
    public class OrderController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult OrderProducts()
        {
            return View("OrderProducts");
        }

        [HttpPost]
        public IActionResult PlaceOrder(int numberOfPizzas)
        {
            var pizzaOrders = new List<Product>();

            for (int i = 0; i < numberOfPizzas; i++)
            {
                pizzaOrders.Add(new Product());
            }

            return View("OrderPizzas", pizzaOrders);
        }

        [HttpPost]
        public IActionResult ProcessOrders(List<Product> model)
        {
            Console.WriteLine("orders:" + model.Count);
            return View("ProcessOrders", model);
        }
    }
}
