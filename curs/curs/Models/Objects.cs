using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace curs.Models
{
    public class Objects:BaseEntity
    {
        [Display(Name = "Название объекта")]
        public string NameObject { get; set; }
        [Display(Name = "Заказчик")]
        public string Customer { get; set; }
        [Display(Name = "Генеральный подрядчик")]
        public string GeneralConstractor { get; set; }
        [Display(Name = "Дата заключения контракта")]
        public DateTime ContractConclusionDate { get; set; }
        [Display(Name = "Дата завершения строительства")]
        public DateTime DeliveryDate { get; set; }
        [Display(Name = "Дата сдачи объекта")]
        public DateTime StartUp { get; set; }
        [Display(Name = "Фотография объекта")]
        public string Photo { get; set; }
        public virtual ICollection<Materials> Materials { get; set; }
        public virtual ICollection<Works> Works { get; set; }
    }
}