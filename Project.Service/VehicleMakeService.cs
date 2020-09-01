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
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IRepository<VehicleMakeEntity> VehicleMakeRepository;

        public VehicleMakeService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            VehicleMakeRepository = unitOfWork.Repository<VehicleMakeEntity>();
        }

        public async Task<IVehicleMake> GetById(int id)
        {
            return Mapper.Map<VehicleMake>(await VehicleMakeRepository.GetById(id));
        }

        public async Task<List<IVehicleMake>> GetAll()
        {
            return new List<IVehicleMake>(Mapper.Map<List<VehicleMake>>(await VehicleMakeRepository.GetAll()));
        }

        public async Task Create(IVehicleMake make)
        {
            VehicleMakeRepository.Insert(Mapper.Map<VehicleMakeEntity>(make));
            await UnitOfWork.Save();
        }

        public async Task Update(IVehicleMake make)
        {
            VehicleMakeRepository.Update(Mapper.Map<VehicleMakeEntity>(make));
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await VehicleMakeRepository.Delete(id);
            await UnitOfWork.Save();
        }
    }
}
