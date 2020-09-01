using Project.Model;
using Project.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebAPI
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            AutoMapper.Mapper.CreateMap<VehicleMake, VehicleMakeModel>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleMakeModel, VehicleMake>().ReverseMap();

            AutoMapper.Mapper.CreateMap<VehicleModel, VehicleModelModel>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleModelModel, VehicleModel>().ReverseMap();

        }
    }
}