using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IRepository<VehicleModelEntity> VehicleModelRepository;
        
        public VehicleModelService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            VehicleModelRepository = unitOfWork.Repository<VehicleModelEntity>();
        }
        public async Task<IVehicleModel> GetById(int id)
        {
            return Mapper.Map<VehicleModel>(await VehicleModelRepository.GetById(id));
        }

        public async Task<List<IVehicleModel>> GetAll()
        {
            return new List<IVehicleModel>(Mapper.Map<List<VehicleModel>>(await VehicleModelRepository.GetAll()));
        }

        public async Task Create(IVehicleModel model)
        {
            VehicleModelRepository.Insert(Mapper.Map<VehicleModelEntity>(model));
            await UnitOfWork.Save();
        }

        public async Task Update(IVehicleModel model)
        {
            VehicleModelRepository.Update(Mapper.Map<VehicleModelEntity>(model));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await VehicleModelRepository.Delete(id);
            await UnitOfWork.Save();
        }
    }
}
