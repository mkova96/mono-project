using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Project.Model;
using Project.Model.Common;
using Project.Service;
using Project.Service.Common;

namespace Project.WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class VehicleModelController : ApiController
    {
        protected IVehicleModelService Service { get; private set; }

        public VehicleModelController(IVehicleModelService Service)
        {
            this.Service = Service;
        }

        [HttpGet]
        [Route("vehiclemodel")]
        public async Task<List<IVehicleModel>> GetAsync()
        {
            return await Service.GetAll();
        }

        [HttpGet]
        [Route("vehiclemodel/{id}")]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            var model = await Service.GetById(id);

            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpDelete]
        [Route("vehiclemodel/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await Service.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("vehiclemodel/create")]
        public async Task<HttpResponseMessage> Create(VehicleModel model)
        {
            try
            {
                if (model.Abrv == "" || model.Name == "" || model == null || model.MakeId == 0)
                {
                    throw new ArgumentNullException();
                }
                await Service.Create(model);
                return Request.CreateResponse(HttpStatusCode.Created);

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        [HttpPut]
        [Route("vehiclemodel/{id}")]
        public async Task<HttpResponseMessage> Update(VehicleModel model, int id)
        {
            model.Id = id;
            try
            {
                if (model.Abrv == "" || model.Name == "" || model == null || model.MakeId == 0)
                {
                    throw new ArgumentNullException();
                }
                await Service.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}