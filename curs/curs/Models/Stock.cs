using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace curs.Models
{
    public class Stock:BaseEntity
    {
        public string NameMaterial { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Manufacturer { get; set; }
        public int Certificate { get; set; }
        public DateTime DateCertificate { get; set; }
        public decimal Price { get; set; }
        public string Provider { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Photo { get; set; }
        public ICollection<Materials> Materials { get; set; }
    }
}