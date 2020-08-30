using Project.DAL;
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
        #region Methods

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            //Note: Our fake context will act as database

            Bind<IVehicleDbContext>().To<VehicleDbContext>().InSingletonScope();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            //Bind<IVehicleDbContext>().To<VehicleDbContext>().InSingletonScope();
            //Bind<IRepository>().To<Repository>();
        }

        #endregion Methods
    }
}
