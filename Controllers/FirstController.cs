using AppMVC.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Net.Controllers
{
    public class FirstController : Controller
    {

        private readonly ILogger<FirstController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ProductService _productService;

        public FirstController(ILogger<FirstController> logger, IWebHostEnvironment env, ProductService productService)
        {
            _logger = logger;
            _env = env;
            _productService = productService;
        }
        [TempData]
        public string? StatusMessge { get; set; }
        public IActionResult Index()
        {
            _logger.LogInformation("Index First action called");
            return Content("Hello from FirstController!", "text/plain");
        }
        public IActionResult Img()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot", "images", "history.png");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/png");
            // return PhysicalFile(filePath, "image/png");
        }
            
        public IActionResult Products(int? id)
        {
            var products = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (products == null)
            {
                StatusMessge = "Product not found";
                return RedirectToAction("Index", "Home");
            }
            ViewData["Title"] = products.Name;
            return View(products);
        }

    }
}