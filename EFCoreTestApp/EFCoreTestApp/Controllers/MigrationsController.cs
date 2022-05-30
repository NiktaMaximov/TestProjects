using EFCoreTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EFCoreTestApp.Controllers
{
    public class MigrationsController : Controller
    {
        private MigrationsManager _manager;

        public MigrationsController(MigrationsManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(string context)
        {
            ViewBag.Context = _manager.ContextName = context ?? _manager.ContextNames.First();
            return View(_manager);
        }

        [HttpPost]
        public IActionResult Migrate(string context, string migration)
        {
            _manager.ContextName = context;
            _manager.Migrate(context, migration);

            return RedirectToAction(nameof(Index), new { context = context });
        }

        [HttpPost]
        public IActionResult Seed(string context)
        {
            _manager.ContextName = context;
            SeedData.Seed(_manager.Context);

            return RedirectToAction(nameof(Index), new { context = context });
        }

        [HttpPost]
        public IActionResult Clear(string context)
        {
            _manager.ContextName = context;
            SeedData.ClearData(_manager.Context);

            return RedirectToAction(nameof(Index), new { context = context });
        }
    }
}
