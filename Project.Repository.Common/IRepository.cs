using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IRepository<T> : IDisposable
    {
        Task<T> GetById(object id);
        Task<List<T>> GetAll();
        void Update(T entity);
        void Insert(T entity);
        Task Delete(object id);
    }
}
