using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OrderApi.Http;
using OrderApi.Models;
using OrderApi.Repository.Interfaces;
using OrderApi.Services.Interfaces;

namespace OrderApi.Services
{
    public abstract class BaseServices<T> : IBaseService<T> where T : BaseModel
    {
        public abstract IBaseRepository<T> Repository { get; set; }

        public List<T> GetAll()
        {
            return Repository.FindMany(x => true);
        }

        public T GetById(Guid id)
        {
            var document = Repository.Find(x => x.Id == id);

            if(document == null)
                throw new HttpNotFound(id.ToString());

            return document;
        }

        public T Create(T document)
        {
            return Repository.Insert(document);
        }

        public bool Update(Guid id, T document)
        {
            var result = Repository.Replace(x => x.Id == id, document);
            
            if(!result) throw new HttpNotFound(id.ToString());

            return result;
        }

        public bool UpdateField(Guid id, Expression<Func<T, object>> field, object value)
        {
            var result = Repository.Update(x => x.Id == id, field, value);
            
            if(!result) throw new HttpNotFound(id.ToString());

            return result;
        }

        public bool Remove(Guid id)
        {
            var result = Repository.Delete(x => x.Id == id);
            
            if(!result) throw new HttpNotFound(id.ToString());

            return result;
        }

        public bool IsValid(Guid id)
        {
            var document = Repository.Find(x => x.Id == id);
            return document != null;
        }
    }
}