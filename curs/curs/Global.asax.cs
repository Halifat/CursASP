using curs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace curs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Инициализация БД путем выполнения кода в классе инициализатора с использование методов EF
            Database.SetInitializer(new BuildingContractorInitializer());

            //Инициализация БД путем запуска SQL инструкции из файла FillDB.sql
            //Database.SetInitializer(new ToplivoDbInitializer_runSQL());

            using (var db = new BuildingContractorContext())
            {
                db.Database.Initialize(true);
            }

        }
    }
}
