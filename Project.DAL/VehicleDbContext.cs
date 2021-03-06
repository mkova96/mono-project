﻿using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class VehicleDbContext : DbContext, IVehicleDbContext
    {

        static VehicleDbContext()
        {
            System.Data.Entity.Database.SetInitializer<VehicleDbContext>(null);
        }

        public VehicleDbContext(): base("StringDBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<VehicleMakeEntity> VehicleMakes { get; set; }

        public DbSet<VehicleModelEntity> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.Configuration.ProxyCreationEnabled = false;
        }
    }
}
