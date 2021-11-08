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
        
        public ActionResult Index()
        { // ddl olarak categorileri doldurmak...

            return View();
        }
    }


    //ÖDEV
    // category Controller ve product controller oluştur
    // category ve product entitileri
    // db'ye bu iki entity'i ekle.
    // CRUD işlemlerini yapınız

   
}