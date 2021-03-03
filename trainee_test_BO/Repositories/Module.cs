using Domain.Abstractions.Repositories;

namespace Repositories
{
    public class Module
    {
        public static void Initialize()
        {
            IoC.IoC.AddScopped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
