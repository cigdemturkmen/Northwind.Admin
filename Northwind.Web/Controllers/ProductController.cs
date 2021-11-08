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
    public class ProductController : Controller
    {

        private readonly NorthwindDbContext _db;

        public ProductController()
        {
            _db = new NorthwindDbContext();
        }

        public ActionResult List()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        public ActionResult Add() 
        {
            ViewBag.Categories = _db.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!_db.Products.Any(x => x.ProductName == model.ProductName))
            {
                _db.Products.Add(model);

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    return RedirectToAction("List", "Product");
                }
            }
            else
            {
                ViewBag.Message = "Bu isimde bir ürün mevcut. Lütfen başka bir ürün ismi giriniz.";
                return View(model);
            }

            return null;
            
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categories = _db.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList(); // ddl olarak categorileri doldurur.

            var product = _db.Products.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                return View(product);
            }
            else
            {
                TempData["Message"] = "Böyle bir ürün mevcut değil.";
            }
            return RedirectToAction("Add", "Product");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            
            var product = _db.Products.FirstOrDefault(x => x.ProductId == model.ProductId);

            if (product != null)
            {
                product.ProductName = model.ProductName;
                product.CategoryId = model.CategoryId;
                product.QuantityPerUnit = model.QuantityPerUnit;
                product.UnitPrice = model.UnitPrice;
               
                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    TempData["EditSuccessful"] = "Güncelleme başarılı.";
                    return RedirectToAction("List", "Product");
                }
            }
            return null;
        }

        public ActionResult Deletet(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                _db.Products.Remove(product);

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    return RedirectToAction("List", "Product");
                }
            }
            return null;
        }
    }
}