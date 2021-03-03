using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employees;
        public EmployeeService(IEmployeeRepository employees)
        {
            this.employees = employees;
        }
        public async Task<Employee> Add(Employee employee)
        {
            return await employees.Add(employee);
        }

        public async Task<Employee> Delete(int id)
        {
            return await employees.Delete(id);
        }

        public async Task<ICollection<Employee>> GetAll()
        {
            var all = await employees.GetAll();
            return all.Where(e => !e.IsDeleted).ToList();
        }

        public async Task<Employee> GetById(int id)
        {
            var employee= await employees.GetById(id);

            if(employee.IsDeleted)
                throw new ArgumentException( "Employee was deleted", nameof(id));

            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            return await employees.Update(employee);
        }
    }
}
