using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<VehicleMake> GetById(int id);
        Task<List<VehicleMake>> GetAll();
        Task<int> Create(VehicleMake make);
        Task<VehicleMake> Update(VehicleMake make);
        Task Delete(int id);
    }
}
