using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace curs.Models
{
    public class Works:BaseEntity
    {
        public Guid KindWorkID { get; set; }
        public Guid ObjectsID { get; set; }
        public virtual KindWork KindWork { get; set; }
        public virtual Objects Objects { get; set; }
    }
}