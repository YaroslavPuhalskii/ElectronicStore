using System;
using System.Collections.Generic;

namespace ElectronicStore.Entities.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public DateTime Birth { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
