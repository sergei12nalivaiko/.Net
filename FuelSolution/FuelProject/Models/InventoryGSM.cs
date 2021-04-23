using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FuelProject.Models
{
    public class InventoryGSM
    {
        public int ID { get; set; }
        [Display(Name = "Дата")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime Datetimer { get; set; }
        [Display(Name = "Емкость 13")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement13 { get; set; }
        [Display(Name = "Емкость 15")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement15 { get; set; }

        [Display(Name = "Емкость № 16")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement16 { get; set; }
        


    }
}