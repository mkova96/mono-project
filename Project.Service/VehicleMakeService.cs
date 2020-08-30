using Project.DAL.Entities;
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
        private readonly IRepository<VehicleMake> VehicleMakeRepository;

        public VehicleMakeService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            VehicleMakeRepository = unitOfWork.Repository<VehicleMake>();
        }

        public async Task<VehicleMake> GetById(int id)
        {
            return await VehicleMakeRepository.GetById(id);
        }

        public async Task<List<VehicleMake>> GetAll()
        {
            return await VehicleMakeRepository.GetAll();
        }

        public async Task<int> Create(VehicleMake make)
        {
            VehicleMakeRepository.Insert(make);
            await UnitOfWork.Save();

            return make.Id;
        }

        public async Task<VehicleMake> Update(VehicleMake make)
        {
            VehicleMakeRepository.Update(make);
            await UnitOfWork.Save();

            return make;
        }

        public async Task Delete(int id)
        {
            await VehicleMakeRepository.Delete(id);
            await UnitOfWork.Save();
        }
    }
}
