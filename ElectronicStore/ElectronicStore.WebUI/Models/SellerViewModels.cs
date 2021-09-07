using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
}