using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace curs.Models
{
    public class KindWork:BaseEntity
    {
        public int NumberLicense { get; set; }
        public DateTime DateLicense { get; set; }
        public DateTime ExpirationLicense { get; set; }
        public decimal PriceWork { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public ICollection<Works> Works { get; set; }
    }
}