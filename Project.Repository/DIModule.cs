using Project.DAL;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            AutoMapper.Mapper.CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IVehicleMake, VehicleMake>().ReverseMap();

            AutoMapper.Mapper.CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IVehicleModel, VehicleModel>().ReverseMap();

            Bind<IVehicleDbContext>().To<VehicleDbContext>().InSingletonScope();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
