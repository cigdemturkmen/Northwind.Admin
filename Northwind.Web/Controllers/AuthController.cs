using Northwind.Web.Models.Entities;
using Northwind.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly NorthwindDbContext _db; // readonly olunca sadece constructer'da  veya class eviyesinde  set edilebiliyor!!!

        public AuthController()
        {
            // IOC Container, Ninject vb DI 3rd dll.... Core'da built in olarak geliyor.
            _db = new NorthwindDbContext();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // !!!!!!!!!!!!!!
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // db'ye user'ı kaydediyoruz.
            User yeniKullanici = new User()
            {
                Firstname = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                CreatedDate = DateTime.Now,
                IsActive = true,
                CreatedById = -1,
            };

            _db.Users.Add(yeniKullanici);

            var sonuc = _db.SaveChanges();

            if (sonuc> 0)
            {
                TempData["Message"] = "Kullanıcı eklendi!";
                return RedirectToAction("Login");  // ya anasayfaya ya login sayfasına yönlendiririz. 
            }

            TempData["Message"] = "Kullanıcı eklenemedi!";
            return View(model);
            
        }

        
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken] // get ile farklı ise post'a sokmuyor (atak yapılırsa, ataklara karşı önlem)
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var kullanici = _db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password && x.IsActive);

            if (kullanici != null)
            {
                // session

                Session.Add("LoginBilgileri", kullanici);
                return RedirectToAction("Index", "Home"); // eğer login olduysa home controller içindeki indexe gidecek.
            }
            else
            {
                ViewBag.Message = "Kullanıcı bulunamadı. Bilgilerinizi kontrol ediniz.";            
            }

            return View(model);
           
        }

        public ActionResult Logout()
        {
            Session.Remove("LoginBilgileri");
            return RedirectToAction("Login");
            
        }
    }
}