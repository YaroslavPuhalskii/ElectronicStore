using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.WebUI.Models
{
    public class ProductIndexView
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        [Required]
        [Display(Name ="Продукт")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Катергория")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Стоимость")]
        public decimal Price { get; set; }
    }

    public class ProductEditView
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3,ErrorMessage = "Имя должно от 3 букв до 50")]
        [Display(Name = "Название продукта")]
        public string Name { get; set; }
        [Required]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "Имя должно от 3 букв до 400")]
        [Display(Name = "Название продукта")]
        public string Description { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно от 3 букв до 50")]
        [Display(Name = "Название продукта")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(1, int.MaxValue, ErrorMessage = "Недопустимая цена")]
        public decimal Price { get; set; }
    }

    public class ProductCreateView 
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно от 3 букв до 50")]
        [Display(Name = "Название продукта")]
        public string Name { get; set; }
        [Required]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "Имя должно от 3 букв до 400")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно от 3 букв до 50")]
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(1, int.MaxValue, ErrorMessage = "Недопустимая цена")]
        public decimal Price { get; set; }
    }

}