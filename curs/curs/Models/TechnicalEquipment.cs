using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace curs.Models
{
    public class TechnicalEquipment:BaseEntity
    {
        [Display(Name = "Название оборудования")]
        public string NameTech { get; set; }
        [Display(Name = "Использование оборудования")]
        public string UseTech { get; set; }
        [Display(Name = "Дата покупки")]
        public DateTime DatePurchase { get; set; }
        [Display(Name = "Срок эксплуатации")]
        public DateTime Exploitation { get; set; }
    }
}