using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.WebUI.Models
{
    public class ClientIndexView
    {
        [HiddenInput(DisplayValue = false)]
        public int ClientId { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Адресс")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime Birth { get; set; }
    }
}