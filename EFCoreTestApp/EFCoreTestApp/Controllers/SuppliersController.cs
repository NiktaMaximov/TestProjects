using EFCoreTestApp.Dal;
using EFCoreTestApp.Models;
using EFCoreTestApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EFCoreTestApp.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupplierRepository _repo;
        private EFDatabaseContext _eFDatabase;

        public SuppliersController(ISupplierRepository repo, EFDatabaseContext eFDatabase)
        {
            _repo = repo;
            _eFDatabase = eFDatabase;
        }

        public IActionResult Index()
        {
            ViewBag.SupplierEditId = TempData["SupplierEditId"];
            ViewBag.SupplierCreateId = TempData["SupplierCreateId"];
            ViewBag.SupplierRelationshipId = TempData["SupplierRelationshipId"];
            return View(_repo.GetAll());
        }

        public IActionResult Edit(long id)
        {
            TempData["SupplierEditId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(Supplier supplier)
        {
            _repo.Update(supplier);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create(long id)
        {
            TempData["SupplierCreateId"] = id;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Change(long id)
        {
            TempData["SupplierRelationshipId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Change(long Id, Product[] products)
        {
            _eFDatabase.Products.UpdateRange(products.Where(p => p.SupplierId != Id));
            _eFDatabase.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
