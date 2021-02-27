using Microsoft.AspNetCore.Mvc;
using onlineshop1.Data;
using onlineshop1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineshop1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagsController : Controller
    {
        private ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //var data = _db.SpecialTags.ToList();
            return View(_db.SpecialTags.ToList());
        }
        //Create Get Action Method

        public ActionResult Create()
        {
            return View();
        }

        //Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Add(specialTags);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product type has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(specialTags);
        }
        //Edit Get action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = _db.SpecialTags.Find(id);
            if (specialTags == null)
            {
                return NotFound();
            }
            return View(specialTags);
        }

        //Edit Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.Update(specialTags);
                await _db.SaveChangesAsync();
                TempData["Edit"] = "Product type has been Edit";
                return RedirectToAction(nameof(Index));
            }

            return View(specialTags);
        }

        //Details Get action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTag = _db.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }

        //Details Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecialTags SpecialTags)
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

            var specialTag = _db.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }

        //Delete Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpecialTags SpecialTags)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != SpecialTags.Id)
            {
                return NotFound();
            }

            var specialTag = _db.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(specialTag);
                await _db.SaveChangesAsync();
                TempData["Delete"] = "Product type has been Delete";
                return RedirectToAction(nameof(Index));
            }

            return View(specialTag);
        }

    }
}
