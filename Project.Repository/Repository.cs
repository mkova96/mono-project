using Project.DAL;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IVehicleDbContext context;
        public DbSet<T> dbSet;

        public Repository(IVehicleDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task Update(T entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

        }

        public async Task Delete(object id)
        {
            T Entity = await dbSet.FindAsync(id);
            dbSet.Remove(Entity);

            //context.Entry(Entity).State = EntityState.Deleted;
        }
        private bool disposed = false;
       
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
