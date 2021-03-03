using Domain.Abstractions.Services;

namespace Services
{
    public class Module
    {
        public static void Initialize()
        {
            IoC.IoC.AddScopped<IEmployeeService, EmployeeService>();
        }
    }
}
