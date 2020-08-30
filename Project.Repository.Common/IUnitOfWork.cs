using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repositories this instance.
        /// </summary>
        /// <typeparam name=”T”></typeparam>
        /// <returns></returns>
        IRepository<T> Repository<T>() where T : class;
        /// <summary>
        /// Saves this instance.
        /// </summary>
        Task<int> Save();
    }
}
