using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Project.Common;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Service;
using Project.Service.Common;
using Project.WebAPI.Models;

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

        //vehiclemodel?pagenumber=1&pagesize=5&orderby=name&asc=true&filter=d
        [HttpGet]
        [Route("vehiclemodel")]
        public async Task<List<VehicleModelModel>> GetAsync([FromUri] UriParameters p)
        {
            //default values
            Expression<Func<VehicleModelEntity, object>> OrderBy = null;
            Expression<Func<VehicleModelEntity, bool>> Filter = null;
            bool Asc = true;
            int PageNumber = 1;
            int PageSize = 5;

            if (!p.Filter.Equals(""))
            {
                Filter = (x => x.Name.Contains(p.Filter) || x.Abrv.Contains(p.Filter));
            }

            if (p.Asc.ToLower().Equals("false"))
            {
                Asc = false;
            }

            if (p.OrderBy.ToLower().Equals("abrv"))
            {
                OrderBy = y => y.Abrv;
            }
            else
            {
                OrderBy = y => y.Name;
            }

            if (p.PageNumber != 0)
            {
                PageNumber = p.PageNumber;
            }
            if (p.PageSize != 0)
            {
                PageSize = p.PageSize;
            }

            return Mapper.Map<List<VehicleModelModel>>(await Service.Get(new GenericParameters<VehicleModelEntity>(OrderBy, Asc, Filter, PageNumber, PageSize)));
        }

        [HttpGet]
        [Route("vehiclemodel/{id}")]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            var model = Mapper.Map<VehicleModelModel>(await Service.GetById(id));

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
                if (model.Abrv == "" || model.Name == "" || model.MakeId == 0)
                {
                    throw new ArgumentNullException();
                }
                await Service.Create(Mapper.Map<VehicleModel>(model));
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
                if (model.Abrv == "" || model.Name == "" || model.MakeId == 0)
                {
                    throw new ArgumentNullException();
                }
                await Service.Update(Mapper.Map<VehicleModel>(model));
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