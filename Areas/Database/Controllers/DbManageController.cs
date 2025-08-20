using AppMVC.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Net.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {

        private readonly AppDbContext _dbContext;
        public DbManageController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: DbManageController
        public IActionResult Index()
        {
            return View();
        }
        [TempData]
        public string? StatusMessage { get; set; }

        [HttpGet]
        public IActionResult DeleteDb()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()
        {
            var success = await _dbContext.Database.EnsureDeletedAsync();
            StatusMessage = success ? "Database deleted successfully." : "Failed to delete the database.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ApplyMigrations()
        {
            await _dbContext.Database.MigrateAsync();
            StatusMessage = "Migrations applied successfully.";
            return RedirectToAction(nameof(Index));
        }

    }
}
