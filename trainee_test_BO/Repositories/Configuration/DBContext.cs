using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Configuration
{
    public class DBContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {         
        }
    }
}
