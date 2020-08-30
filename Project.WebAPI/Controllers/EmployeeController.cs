using Project.DAL.Entities;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    [RoutePrefix("api")]

    public class EmployeeController : ApiController
    {
        protected EmployeeService Service { get; private set; }

        public EmployeeController()
        {
            this.Service = new EmployeeService();
        }

        [HttpGet]
        [Route("vehiclemake")]
        public async Task<List<Employee>> GetAsync()
        {
            return await Service.GetAll();
        }

        [HttpGet]
        [Route("vehiclemake/{id}")]
        public async Task<Employee> GetById(int id)
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
        public async Task<int> Create(Employee Employee)
        {
            return await Service.Create(Employee);
        }

        [HttpPut]
        [Route("vehiclemake/{id}")]
        public async Task<Employee> Update(Employee Employee,int id)
        {
            Employee.Id = id;
            return await Service.Update(Employee);
        }

    }
}