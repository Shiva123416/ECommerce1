using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineshop1.Data;
using onlineshop1.Models;

namespace onlineshop1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //var data = _db.ProductTypes.ToList();
            return View(_db.ProductTypes.ToList()); 
        }

        //Create Get Action Method

        public ActionResult Create()
        {
            return View();
        }

        //Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if(ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product type has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }
        //Edit Get action Method

        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var ProductType = _db.ProductTypes.Find(id);
            if(ProductType==null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        //Edit Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes ProductTypes)
        {
            if(ModelState.IsValid)
            {
                _db.Update(ProductTypes);
                await _db.SaveChangesAsync();
                TempData["Edit"] = "Product type has been Edit";
                return RedirectToAction(nameof(Index));
            }

            return View(ProductTypes);
        }

        //Details Get action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ProductType = _db.ProductTypes.Find(id);
            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        //Details Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ProductTypes ProductTypes)
        {
            return RedirectToAction(nameof(Index));

        }

        //Delete Get action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ProductType = _db.ProductTypes.Find(id);
            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        //Delete Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductTypes ProductTypes)
        {
            if(id==null)
            {
                return NotFound();
            }

            if(id!=ProductTypes.Id)
            {
                return NotFound();
            }

            var ProductType = _db.ProductTypes.Find(id);
            if(ProductType==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(ProductType);
                await _db.SaveChangesAsync();
                TempData["Delete"] = "Product type has been Delete";
                return RedirectToAction(nameof(Index));
            }

            return View(ProductTypes);
        }


    }
}
