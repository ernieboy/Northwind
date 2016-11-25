using System;
using System.Linq.Expressions;
using Core.Common.Data.Business;
using Core.Common.Data.Interfaces;
using LinqKit;
using Northwind.Models;
using System.Linq;

namespace Northwind.Business
{
    public class CustomerBusiness : EntityBusinessBase<Customer>, ICustomerBusiness
    {
        public CustomerBusiness(IDataRepository<Customer> repository) : base(repository)
        {
        }

        /// <summary>
        /// Returns a predicate to filter the data by based on the keywords supplied
        /// </summary>
        /// <param name="keywords">Keywords to filter by</param>
        /// <returns>An expression to use for filtering</returns>
        protected override ExpressionStarter<Customer> BuildSearchFilterPredicate(string[] keywords)
        {
            Expression<Func<Customer, bool>> filterExpression = a => true;
            ExpressionStarter<Customer> predicate = PredicateBuilder.New(filterExpression);
            bool isFilteredQuery = keywords.Any();
            if (!isFilteredQuery) return predicate;

            predicate = filterExpression = a => false;
            foreach (var keyword in keywords)
            {
                var temp = keyword;
                if (temp == null) continue;
                predicate = predicate.Or(p => p.ContactName.ToLower().Contains(temp.ToLower()));
            }
            return predicate;
        }
    }
}