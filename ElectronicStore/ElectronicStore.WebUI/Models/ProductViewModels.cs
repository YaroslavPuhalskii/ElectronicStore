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

        [Display(Name = "Продавец")]
        public string Seller { get; set; }
    }

}