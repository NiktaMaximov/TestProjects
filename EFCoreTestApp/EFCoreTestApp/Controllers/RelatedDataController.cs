using EFCoreTestApp.Models;
using EFCoreTestApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTestApp.Controllers
{
    public class RelatedDataController : Controller
    {
        private ISupplierRepository _repository;
        private IGenericRepository<ConcatDetails> _genericRepositoryDetails;
        private IGenericRepository<ConcatLocation> _genericRepositoryLocation;

        public RelatedDataController(ISupplierRepository repository, IGenericRepository<ConcatDetails> gRepositoryDetails, IGenericRepository<ConcatLocation> gRepositoryLocation)
        {
            _repository = repository;
            _genericRepositoryDetails = gRepositoryDetails;
            _genericRepositoryLocation = gRepositoryLocation;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Concats()
        {
            return View(_genericRepositoryDetails.GetAll());
        }

        public IActionResult Location()
        {
            return View(_genericRepositoryLocation.GetAll());
        }
    }
}
