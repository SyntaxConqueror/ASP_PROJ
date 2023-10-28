using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;

namespace ASP_MVC_PROJ.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public FileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View("DownloadFile");
        }


        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            string content = $"Ім'я: {firstName}\nПрізвище: {lastName}";

            string webPath = _environment.WebRootPath;
            string filePath = Path.Combine(webPath, "Files", fileName + ".txt");
            System.IO.File.WriteAllText(filePath, content, Encoding.UTF8);

            // Повертаємо файл для завантаження
            return File(System.IO.File.ReadAllBytes(filePath), "text/plain", fileName + ".txt");
        }
    }
}
