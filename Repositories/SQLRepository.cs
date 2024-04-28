namespace RentalShopApp.Repositories
{
    using RentalShopApp.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

  
    public class SQLRepository<T>: IRepository<T> where T : class, IEntity
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        public event EventHandler<T>? _itemAdded;
        public event EventHandler<T>? _itemRemoved;

        public SQLRepository(DbContext dbContext, EventHandler<T>? ItemAdded = null)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _itemAdded = ItemAdded;
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T item) 
        { 
           
            _dbSet.Add(item);
            _itemAdded?.Invoke(this, item);
        }

        public void Remove(T item) 
        {
            _dbSet.Remove(item);
            _itemRemoved?.Invoke(this, item);
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
