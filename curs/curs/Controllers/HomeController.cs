using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace curs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id)
        {
               //name = "TechnicalEquipment";
               if (id== "1")
               return RedirectToRoute(new { Controller = "TechnicalEquipments", Action = "Index" });
            if (id == "2")
                return RedirectToRoute(new { Controller = "KindWorks", Action = "Index" });
            if (id == "3")
                return RedirectToRoute(new { Controller = "Stocks", Action = "Index" });
            if (id == "4")
                return RedirectToRoute(new { Controller = "Objects", Action = "Index" });
            else return View();
        }
    }
}