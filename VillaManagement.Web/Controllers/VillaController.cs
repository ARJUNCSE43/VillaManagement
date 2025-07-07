using Microsoft.AspNetCore.Mvc;
using VillaManagement.Application.Common.Interfaces;
using VillaManagement.Domain.Entities;
using VillaManagement.Infrastructure.Data;

namespace VillaManagement.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaRepository _villaRepo;
        public VillaController(IVillaRepository villaRepo)
        {
            _villaRepo = villaRepo;

        }
        public IActionResult Index()
        {
            var villas= _villaRepo.GetAll();
            return View(villas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The description cannot exactly match");
            }
            if (ModelState.IsValid)
            {
                _villaRepo.Add(obj);
                _villaRepo.Save();
                TempData["success"] = "The villa has been created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Update(int villaId)
        {
            Villa? obj= _villaRepo.Get(x => x.Id == villaId);
            // Villa? obj=_db.Villas.Find(villaId)
            // var VillaList=_db.Villas.Where(u=>u.Price>50 && u.Occupancy>0);
            if (obj == null)
            {
                return RedirectToAction("Error","Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Update(Villa obj)
        {
           
            if (ModelState.IsValid && obj.Id>0)
            {
                _villaRepo.Update(obj);
                _villaRepo.Save();
                TempData["success"] = "The villa has been update successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete(int villaId)
        {
            Villa? obj = _villaRepo.Get(x => x.Id == villaId);
            // Villa? obj=_db.Villas.Find(villaId)
            // var VillaList=_db.Villas.Where(u=>u.Price>50 && u.Occupancy>0);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _villaRepo.Get(v => v.Id == obj.Id);
            if (objFromDb is not null)
            {
                _villaRepo.Remove(objFromDb);
                _villaRepo.Save();
                TempData["success"] = "The Villa has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa could not be deleted";
            return View();
        }
    }
}
