using Northwind.Web.Filters;
using Northwind.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    [Auth]
    public class CategoryController : Controller
    {
        private readonly NorthwindDbContext _db;

        public CategoryController()
        {
            _db = new NorthwindDbContext();
        }

        
        public ActionResult List()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        public ActionResult Add()
        {
            var category = new Category();
            return View(category);

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!_db.Categories.Any(x => x.CategoryName.ToLower() == model.CategoryName.ToLower()))
            {
                _db.Categories.Add(model);

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    TempData["Message"] = "Category added!";
                    return RedirectToAction("List", "Category");
                }
            }

            ViewBag.Message = "This category name already exists. Please write a different category name.";
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.CategoryId == id);

            if (category != null)
            {
                return View(category);
            }
            else
            {
                TempData["Message"] = "Category is not found!";
                return RedirectToAction("Add", "Category");
            }     
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            var category = _db.Categories.FirstOrDefault(x => x.CategoryId == model.CategoryId);

            if (category != null)
            {
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    TempData["Message"] = " Category updated!";
                    return RedirectToAction("List", "Category");
                }
            }      
            return null;   
        }

        public ActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.CategoryId == id);

            if (category != null)
            {
                _db.Categories.Remove(category);

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    TempData["Message"] = "Category deleted!";
                    return RedirectToAction("List", "Category");
                }
            }
            return null;
        }

}
}