using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OrderApi.Repository.Interfaces;

namespace OrderApi.Services.Interfaces
{
    public interface IBaseService<T>
    {
        public IBaseRepository<T> Repository { set; get; }
        public List<T> GetAll();
        public T GetById(Guid id);
        public T Create(T document);
        public bool Update(Guid id, T document);
        public bool UpdateField(Guid id, Expression<Func<T, object>> field, object value);
        public bool Remove(Guid id);
        public bool IsValid(Guid id);
    }
}