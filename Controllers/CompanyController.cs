using LR12_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR12_2.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AppDbContext db;
        public CompanyController(AppDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            db.Companies.Add(new Company { Name = "Company1", Location = "Location1" });
            db.Companies.Add(new Company { Name = "Company2", Location = "Location2" });
            db.Companies.Add(new Company { Name = "Company3", Location = "Location3" });
            db.Companies.Add(new Company { Name = "Company4", Location = "Location4" });
            db.Companies.Add(new Company { Name = "Company5", Location = "Location5" });
            db.SaveChanges();

            var companies = db.Companies.ToList();
            return View(companies);
        }
    }
}
