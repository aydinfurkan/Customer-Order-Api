using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OrderApi.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        public T Find(Expression<Func<T, bool>> expression);
        public List<T> FindMany(Expression<Func<T, bool>> expression);
        public T Insert(T document);
        public IEnumerable<T> InsertMany(IEnumerable<T> documents);
        public bool Replace(Expression<Func<T, bool>> expression, T document);
        public bool Update(Expression<Func<T, bool>> expression, Expression<Func<T, object>> field, object value);
        public long UpdateAll(Expression<Func<T, bool>> expression, Expression<Func<T, object>> field, object value);
        public long UpdateManyField(Expression<Func<T, bool>> expression,
            IEnumerable<KeyValuePair<Expression<Func<T, object>>, object>> updates);
        public bool Delete(Expression<Func<T, bool>> expression);
        public long DeleteAll();
    }
}