namespace RentalShopApp.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using RentalShopApp.Data.Entities;

    public class DbRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemDeleted;

        public DbRepository(DbContext dbContext, EventHandler<T>? itemAdded = null)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            ItemAdded = itemAdded;
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T item)
        {

            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            ItemDeleted?.Invoke(this, item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }
    }
}
