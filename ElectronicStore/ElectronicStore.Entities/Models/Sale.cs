using System;

namespace ElectronicStore.Entities.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int? SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public DateTime SaleDate { get; set; }
        public decimal Price { get; set; }
    }
}
