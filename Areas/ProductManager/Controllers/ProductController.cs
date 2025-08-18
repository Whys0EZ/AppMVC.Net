using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Net.Controllers
{
    [Area("ProductManager")]
    public class ProductController : Controller
    {
        private readonly AppMVC.Net.Models.ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(AppMVC.Net.Models.ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }


        // GET: ProductController
        public ActionResult Index()
        {
            // areas/areName/Views/ControllerName/action.cshtml
            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);
        }


    }
}
