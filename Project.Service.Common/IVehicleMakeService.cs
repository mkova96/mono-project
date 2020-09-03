using Project.Common;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IVehicleMake> GetById(int id);
        Task<IEnumerable<IVehicleMake>> Get(GenericParameters<VehicleMakeEntity> p);
        Task Create(IVehicleMake make);
        Task Update(IVehicleMake make);
        Task Delete(int id);
    }
}
