using System;
using System.ComponentModel.DataAnnotations;
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

    public class ClientEditeView
    {
        [HiddenInput(DisplayValue = false)]
        public int ClientId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно от 3 букв до 50")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Фамилия должна от 3 букв до 50")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Адресс должен от 3 букв до 50")]
        [Display(Name = "Адресс")]
        public string Address { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Почта должна от 3 букв до 50")]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите дату основания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birth { get; set; }
    }

    public class ClientCreateView
    {
        [HiddenInput(DisplayValue = false)]
        public int ClientId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно от 3 букв до 50")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Фамилия должна от 3 букв до 50")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Адресс должен от 3 букв до 50")]
        [Display(Name = "Адресс")]
        public string Address { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Почта должна от 3 букв до 50")]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите дату рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birth { get; set; }
    }
}