using Domain.Abstractions.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DBContext context;
        public EmployeeRepository(DBContext _context)
        {
            context = _context;
        }
        public async Task<Employee> Add(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Delete(int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employee is null)
                throw new ArgumentNullException(nameof(id), "Employee cannot be found");

            employee.IsDeleted = true;
            await context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employee is null)
                throw new ArgumentNullException(nameof(id), "Employee cannot be found");

            return employee;
        }

        public async Task<ICollection<Employee>> GetAll()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> Update(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
            return employee;
        }
    }
}
