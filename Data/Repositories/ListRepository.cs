namespace RentalShopApp.Data.Repositories
{
    using RentalShopApp.Data.Entities;
    using System;
    using System.Collections.Generic;

    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {

        private readonly List<T> _items = new();

        public event EventHandler<T>? ItemAdded;
        
        public event EventHandler<T>? ItemDeleted;

        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
            ItemDeleted?.Invoke(this, item);
        }
        public void Save()
        {

        }
        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
    }
}


