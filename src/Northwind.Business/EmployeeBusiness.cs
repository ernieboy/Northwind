using System;
using System.Linq.Expressions;
using Core.Common.Data.Business;
using Core.Common.Data.Interfaces;
using LinqKit;
using Northwind.Models;
using System.Linq;

namespace Northwind.Business
{
    public class EmployeeBusiness : EntityBusinessBase<Employee>,  IEmployeeBusiness
    {
        public EmployeeBusiness(IDataRepository<Employee> repository) : base(repository)
        {
        }

        /// <summary>
        /// Returns a predicate to filter the data by based on the keywords supplied
        /// </summary>
        /// <param name="keywords">Keywords to filter by</param>
        /// <returns>An expression to use for filtering</returns>
        protected override ExpressionStarter<Employee> BuildSearchFilterPredicate(string[] keywords)
        {
            Expression<Func<Employee, bool>> filterExpression = a => true;
            ExpressionStarter<Employee> predicate = PredicateBuilder.New(filterExpression);
            bool isFilteredQuery = keywords.Any();
            if (!isFilteredQuery) return predicate;

            predicate = filterExpression = a => false;
            foreach (var keyword in keywords)
            {
                var temp = keyword;
                if (temp == null) continue;
                predicate = predicate.Or(p => p.FirstName.ToLower().Contains(temp.ToLower()));
                predicate = predicate.Or(p => p.LastName.ToLower().Contains(temp.ToLower()));
                predicate = predicate.Or(p => p.Title.ToLower().Contains(temp.ToLower()));
            }
            return predicate;
        }
    }
}