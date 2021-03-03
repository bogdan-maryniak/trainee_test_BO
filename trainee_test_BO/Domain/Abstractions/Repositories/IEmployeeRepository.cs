using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<Employee> Add(Employee employee);
        public Task<Employee> GetById(int id);
        public Task<ICollection<Employee>> GetAll();
        public Task<Employee> Delete(int id);
        public Task<Employee> Update(Employee employee);
    }
}
