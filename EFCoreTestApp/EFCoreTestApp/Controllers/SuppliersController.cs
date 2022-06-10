using EFCoreTestApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTestApp.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupplierRepository _repo;

        public SuppliersController(ISupplierRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }
    }
}
