using AppMVC.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Net.Controllers
{
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }

        // GET: Planet
        public IActionResult Index()
        {
            return View();
        }

        [BindProperty(SupportsGet = true, Name = "action")]
        public string? Name { get; set; }
        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Jupiter()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        [HttpPost("/saturn.html")]
        public IActionResult Saturn()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Detail(int id)
        {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            if (planet == null)
            {
                _logger.LogWarning("Planet with ID {Id} not found", id);
                return NotFound();
            }
            return View("Detail", planet);
        }

    }
}
