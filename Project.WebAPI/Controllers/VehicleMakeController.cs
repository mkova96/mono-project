using AutoMapper;
using Project.Common;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service;
using Project.Service.Common;
using Project.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class VehicleMakeController : ApiController
    {
        protected IVehicleMakeService Service { get; private set; }
        //protected VehicleMakeService Service { get; private set; }

        public VehicleMakeController(IVehicleMakeService Service)
        {
            this.Service = Service;
        }

        //vehiclemake?pagenumber=1&pagesize=5&orderby=name&asc=true&filter=d
        [HttpGet]
        [Route("vehiclemake")]
        public async Task<List<VehicleMakeModel>> Get([FromUri] UriParameters p)
        {
            //default values
            Expression<Func<VehicleMakeEntity, object>> OrderBy=null;
            Expression<Func<VehicleMakeEntity, bool>> Filter = null;
            bool Asc=true;
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
            }else
            {
                OrderBy = y => y.Name;
            }

            if (p.PageNumber!=0)
            {
                PageNumber = p.PageNumber;
            }
            if (p.PageSize != 0)
            {
                PageSize = p.PageSize;
            }

            return Mapper.Map<List<VehicleMakeModel>>(await Service.Get(new GenericParameters<VehicleMakeEntity>(OrderBy,Asc,Filter,PageNumber,PageSize)));
        }

        [HttpGet]
        [Route("vehiclemake/{id}")]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            var make = Mapper.Map<VehicleMakeModel>(await Service.GetById(id));
            if (make ==null )
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK,make);
        }

        [HttpDelete]
        [Route("vehiclemake/{id}")]
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
        [Route("vehiclemake/create")]
        public async Task<HttpResponseMessage> Create(VehicleMakeModel make)
        {
            try
            {
                if (make.Abrv == "" || make.Name== "")
                {
                    throw new ArgumentNullException();
                }
                await Service.Create(Mapper.Map<VehicleMake>(make));
                return Request.CreateResponse(HttpStatusCode.Created);

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        [HttpPut]
        [Route("vehiclemake/{id}")]
        public async Task<HttpResponseMessage> Update(VehicleMakeModel make, int id)
        {
            make.Id = id;
            try
            {
                if ( make.Abrv=="" || make.Name == "")
                {
                    throw new ArgumentNullException();
                }
                await Service.Update(Mapper.Map<VehicleMake>(make));
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