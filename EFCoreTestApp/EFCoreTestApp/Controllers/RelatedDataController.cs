using EFCoreTestApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTestApp.Controllers
{
    public class RelatedDataController : Controller
    {
        private ISupplierRepository _repository;

        public RelatedDataController(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }
    }
}
