using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FuelProject.Models
{
    public class InventoryFuel
    {
        public int ID { get; set; }
        [Display(Name = "Дата")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime Datetimer { get; set; }
        [Display(Name = "Емкость 17")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement17 { get; set; }
        [Display(Name = "Емкость № 25")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement25 { get; set; }
        [Display(Name = "Емкость № 26")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement26 { get; set; }
        [Display(Name = "Емкость № 27")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement27 { get; set; }
        [Display(Name = "Емкость № 28")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement28 { get; set; }
        [Display(Name = "Емкость № 29")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement29 { get; set; }
        [Display(Name = "Емкость № 30")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Measurement30 { get; set; }
       

    }
}