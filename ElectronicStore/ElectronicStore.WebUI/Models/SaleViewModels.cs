using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.WebUI.Models
{
    public class SaleFilter
    {
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string Product { get; set; }
        public string Seller { get; set; }
        public decimal Price { get; set; }
        public int Date { get; set; }
    }

    public class SaleIndexView
    {
        [HiddenInput(DisplayValue = false)]
        public int SaleId { get; set; }
        [Required]
        [Display(Name = "Клиент")]
        public string Client { get; set; }
        [Required]
        [Display(Name = "Продукт")]
        public string Product { get; set; }
        [Required]
        [Display(Name = "Продавец")]
        public string Seller { get; set; }
        [Required]
        [Display(Name = "Дата покупки")]
        public DateTime SaleDate { get; set; }
        [Required]
        [Display(Name = "Стоимость")]
        public decimal Price { get; set; }
    }
}