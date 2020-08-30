using Project.DAL.Entities;
using Project.Repository.Common;
using Project.Service;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    public class VehicleMakeController : ApiController
    {
        protected IVehicleMakeService Service { get; private set; }

          public VehicleMakeController(IVehicleMakeService Service)
        {
            this.Service = Service;
        }

        [HttpGet]
        [Route("vehiclemake")]
        public async Task<List<VehicleMake>> GetAsync()
        {
            return await Service.GetAll();
        }

        [HttpGet]
        [Route("vehiclemake/{id}")]
        public async Task<VehicleMake> GetById(int id)
        {
            return await Service.GetById(id);
        }

        [HttpDelete]
        [Route("vehiclemake/{id}")]
        public async Task Delete(int id)
        {
            await Service.Delete(id);
        }

        [HttpPost]
        [Route("vehiclemake/create")]
        public async Task<int> Create(VehicleMake make)
        {
            return await Service.Create(make);
        }

        [HttpPut]
        [Route("vehiclemake/{id}")]
        public async Task<VehicleMake> Update(VehicleMake make, int id)
        {
            make.Id = id;
            return await Service.Update(make);
        }
    }
}