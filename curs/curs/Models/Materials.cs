using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace curs.Models
{
    public class Materials:BaseEntity
    {
        public Guid ObjectsID { get; set; }
        public Guid StockID { get; set; }
        public virtual Objects Objects { get; set; }
        public virtual Stock Stock { get; set; }
    }
}