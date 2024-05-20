namespace RentalShopApp.Data.Repositories
{
    using RentalShopApp.Data.Entities;
    public interface IWriteRepository<in T> where T : class, IEntity
    {

        void Add(T item);
        void Remove(T item);
        void Save();
    }
}
