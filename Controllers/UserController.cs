using ASP_MVC_PROJ.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_PROJ.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            Console.WriteLine(user.Age);
            // This action handles the form submission
            
                // Check the user's age and perform any necessary logic
            if (user.Age >= 16)
            {
                return RedirectToAction("OrderProducts", "Order");
            }
            else
            {
                return View("RegistrationError");
            }
           
           
        }
    }
}
