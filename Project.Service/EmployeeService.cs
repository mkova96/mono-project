using Project.DAL.Entities;
using Project.Repository;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class EmployeeService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private IRepository<Employee> employeeRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref=”EmployeeService”/> class.
        /// </summary>
        public EmployeeService()
        {
            employeeRepository = unitOfWork.Repository<Employee>();
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name=”id”>The identifier.</param>
        /// <returns></returns>
        public async Task<Employee> GetById(int id)
        {
            return await employeeRepository.GetById(id);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAll()
        {
            return await employeeRepository.GetAll();
        }
        /// <summary>
        /// Creates the specified employee.
        /// </summary>
        /// <param name=”employee”>The employee.</param>
        /// <returns></returns>
        public async Task<int> Create(Employee employee)
        {
            employeeRepository.Insert(employee);
            await unitOfWork.Save();

            return employee.Id;
        }
        /// <summary>
        /// Updates the specified employee.
        /// </summary>
        /// <param name=”employee”>The employee.</param>
        public async Task<Employee> Update(Employee employee)
        {
            System.Diagnostics.Debug.WriteLine("update1");
            await employeeRepository.Update(employee);
            await unitOfWork.Save();

            return employee;
        }
        /// <summary>
        /// Deletes the specified employee.
        /// </summary>
        /// <param name=”employee”>The employee.</param>
        public async Task Delete(int id)
        {
            await employeeRepository.Delete(id);
            await unitOfWork.Save();
        }
    }
}
