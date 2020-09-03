using Project.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T> GetById(object id);
        Task<IEnumerable<T>> Get(GenericParameters<T> q);
        void Update(T entity);
        void Insert(T entity);
        Task Delete(object id);
    }
}
