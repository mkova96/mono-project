using Project.DAL;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IVehicleDbContext Context;
        private readonly DbSet<T> DbSet;

        public Repository(IVehicleDbContext context)
        {
            this.Context = context;
            DbSet = context.Set<T>();
        }
        public async Task<T> GetById(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public void Insert(T entity)
        {
            if (Context.Entry(entity).State != EntityState.Detached)
            {
                Context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {

            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            Context.Entry(entity).State = EntityState.Modified;

        }

        public async Task Delete(object id)
        {
            T Entity = await DbSet.FindAsync(id);
            DbSet.Remove(Entity);
        }
        private bool disposed = false;
       
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
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
