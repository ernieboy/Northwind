using Core.Common.Data.Repositories;
using Northwind.Models;

namespace Northwind.DataAccess.Repositories
{
    public class CustomerRepository : EfDataRepositoryBase<Customer, NorthwindSqliteDbContext>,
     ICustomerRepository
    {
        public CustomerRepository()
        { }

        public CustomerRepository(NorthwindSqliteDbContext context)
        {
            Context = context;
        }
    }
}
