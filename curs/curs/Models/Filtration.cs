using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace curs.Models
{
    public class Filtration
    {
        public IEnumerable<TechnicalEquipment> Tech;
        public SelectList Names;
    }
}