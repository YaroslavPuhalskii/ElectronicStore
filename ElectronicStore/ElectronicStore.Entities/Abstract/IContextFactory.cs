using System.Data.Entity;

namespace ElectronicStore.Entities.Abstract
{
    public interface IContextFactory
    {
        DbContext GetContext();
    }
}
