using EFCoreTestApp.Models;
using EFCoreTestApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EFCoreTestApp.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository _repo;

        public HomeController(IDataRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string category = null, decimal? price = null)
        {
            var products = _repo.GetFilterProducts(category, price);
            ViewBag.Category = category;
            ViewBag.Price = price;
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            return View("Editor", new Product());
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repo.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(long id)
        {
            ViewBag.CreateMode = false;
            return View("Editor", _repo.GetProduct(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _repo.UpadteProduct(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            _repo.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
