using Core.Common.Data.Repositories;
using Northwind.Models;

namespace Northwind.DataAccess.Repositories
{
    public class EmployeeRepository : EfDataRepositoryBase<Employee,
        NorthwindSqliteDbContext>, IEmployeeRepository
    {
        public EmployeeRepository()
        {

        }

        public EmployeeRepository(NorthwindSqliteDbContext context)
        {
            Context = context;
        }
    }
}