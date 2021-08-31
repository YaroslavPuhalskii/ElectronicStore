using ElectronicStore.Entities.Models;

namespace ElectronicStore.Core.Repositories
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo()
        { }
    }
}
