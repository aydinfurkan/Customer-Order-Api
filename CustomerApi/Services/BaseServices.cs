using System;
using System.Collections.Generic;
using CustomerApi.Http;
using CustomerApi.Models;
using CustomerApi.Repository.Interfaces;
using CustomerApi.Services.Interfaces;

namespace CustomerApi.Services
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
            return Repository.Replace(x => x.Id == id, document);
        }

        public bool Remove(Guid id)
        {
            return Repository.Delete(x => x.Id == id);
        }

        public bool IsValid(Guid id)
        {
            var document = Repository.Find(x => x.Id == id);
            return document != null;
        }
    }
}