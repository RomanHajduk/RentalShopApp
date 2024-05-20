namespace RentalShopApp.Data.Repositories
{
    using RentalShopApp.Data.Entities;
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
    }
}
