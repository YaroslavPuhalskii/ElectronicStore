using ElectronicStore.Entities.Abstract;
using System.Data.Entity;

namespace ElectronicStore.Entities.Factory
{
    public class ContextFactory : IContextFactory
    {
        public DbContext GetContext()
        {
            return new EFContext();
        }
    }
}
