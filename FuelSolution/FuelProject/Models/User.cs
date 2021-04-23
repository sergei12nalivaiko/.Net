using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FuelProject.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string LastName { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string MiddleName { get; set; }
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Login { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Password { get; set; }
        [Display(Name = "Роль")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Role { get; set; }
    }
}