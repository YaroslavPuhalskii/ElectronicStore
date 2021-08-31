using ElectronicStore.Entities.Models;
using System.Data.Entity;

namespace ElectronicStore.Entities
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("name=EFContext")
        {
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}