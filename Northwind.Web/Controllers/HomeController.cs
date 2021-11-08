using Northwind.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        { // ddl olarak categorileri doldurmak...

            return View();
        }
    }

    // category Controller ve rpoduct controller oluştur
    // category ve product entitileri
    // db'ye bu iki entity'i ekle.
    // CRUD işlemlerini yapınız

   
}