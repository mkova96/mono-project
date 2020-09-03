using Project.Common;
using Project.DAL.Entities;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModel> GetById(int id);
        Task<List<IVehicleModel>> Get(GenericParameters<VehicleModelEntity> p);
        Task Create(IVehicleModel model);
        Task Update(IVehicleModel model);
        Task Delete(int id);
    }
}
