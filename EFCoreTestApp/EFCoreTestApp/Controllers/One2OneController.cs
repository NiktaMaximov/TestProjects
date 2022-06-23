using EFCoreTestApp.Dal;
using EFCoreTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreTestApp.Controllers
{
    public class One2OneController : Controller
    {
        private EFDatabaseContext _context;

        public One2OneController(EFDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Set<ConcatDetails>().Include(cd => cd.Supplier));
        }

        public IActionResult Create()
        {
            return View("ConcatEditor");
        }

        public IActionResult Editor(long id)
        {
            ViewBag.Suppliers = _context.Suppliers.Include(s => s.Concat);
            return View("ConcatEditor", _context.Set<ConcatDetails>().Include(cd => cd.Supplier).First(cd => cd.ID == id));
        }

        [HttpPost]
        public IActionResult Update(ConcatDetails concatDetails, long? targetSupplierId, long[] spares)
        {
            if(concatDetails.ID == 0)
            {
                _context.Add<ConcatDetails>(concatDetails);
            }
            else
            {
                _context.Update<ConcatDetails>(concatDetails);

                if(targetSupplierId.HasValue)
                {
                    if(spares.Contains(targetSupplierId.Value))
                    {
                        concatDetails.SupplierId = targetSupplierId.Value;
                    }
                    else
                    {
                        ConcatDetails targetDetails = _context.Set<ConcatDetails>().FirstOrDefault(cd => cd.SupplierId == targetSupplierId);
                        targetDetails.SupplierId = null;
                        targetDetails.SupplierId = targetSupplierId.Value;
                        _context.SaveChanges();

                        // Обязательное отношение
                        //ConcatDetails targetDetails = _context.Set<ConcatDetails>().FirstOrDefault(cd => cd.SupplierId == targetSupplierId);
                        //targetDetails.SupplierId = concatDetails.Supplier.ID;
                        //Supplier temp = new Supplier { Name = "Temp" };
                        //concatDetails.Supplier = temp;
                        //_context.SaveChanges();

                        //temp.Concat = null;
                        //concatDetails.SupplierId = targetSupplierId.Value;
                        //_context.Suppliers.Remove(temp);
                    }
                }
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
