using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public interface IVehicleDbContext : IDisposable
    {
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync();

        DbSet<VehicleMakeEntity> VehicleMakes { get; set; }

        DbSet<VehicleModelEntity> VehicleModels { get; set; }
    }
}
