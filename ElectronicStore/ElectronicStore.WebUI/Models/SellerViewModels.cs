using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ElectronicStore.WebUI.Models
{
    public class SellerFilter
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SellerIndexView
    {
        [HiddenInput(DisplayValue = false)]
        public int SellerId { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Дата основания")]
        public DateTime Birth { get; set; }
    }

    public class SellerEditView
    {
        [HiddenInput(DisplayValue = false)]
        public int SellerId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно от 2 букв до 50")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Почта должна от 5 букв до 50")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Введите дату основания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Bith { get; set; }
    }

    public class SellerCreateView
    {
        [HiddenInput(DisplayValue = false)]
        public int SellerId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно от 2 букв до 50")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Почта должна от 5 букв до 50")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Введите дату основания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Bith { get; set; }
    }
}