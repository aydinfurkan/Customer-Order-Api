using System;
using System.Collections.Generic;
using CustomerApi.Repository.Interfaces;

namespace CustomerApi.Services.Interfaces
{
    public interface IBaseService<T>
    {
        public IBaseRepository<T> Repository { set; get; }
        public List<T> GetAll();
        public T GetById(Guid id);
        public T Create(T document);
        public bool Update(Guid id, T document);
        public bool Remove(Guid id);
        public bool IsValid(Guid id);
    }
}