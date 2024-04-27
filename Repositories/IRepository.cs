namespace RentalShopApp.Repositories
{
    using RentalShopApp.Entities;
    public interface IRepository<T> : IReadRepository<T> , IWriteRepository<T> where T : class, IEntity
    {
    }
}
