using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FuelProject.Models
{
    public class FuelDailyStatement
    {
        public int ID { get; set; }
        [Display(Name = "№")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int NumberStatement { get; set; }
        [Display(Name = "Дата")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime Date { get; set; }
        [Display(Name = "Локомотив")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string LocomotiveNumber { get; set; }
        [Display(Name = "№Маршрута")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int RouteNumber { get; set; }
        [Display(Name = "ФИО машиниста")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string LNameLocDriver { get; set; }
        [Display(Name = "Счетчик до")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int CounterReadingBefore { get; set; }
        [Display(Name = "Счетчик после")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int CounterReadingAfter { get; set; }
        [Display(Name = "Л")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int VolumeLiters { get; set; }
        [Display(Name = "Плотность")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double Density { get; set; }
        [Display(Name = "КГ")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Weight { get; set; }
        [Display(Name = "Организация")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Organization { get; set; }
        [Display(Name = "Вид ГСМ")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string HomeDepo { get; set; }
    }
}