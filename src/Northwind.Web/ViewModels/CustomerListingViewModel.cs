using System.Collections.Generic;
using Northwind.Models;

namespace Northwind.Web.ViewModels
{
    public class CustomerListingViewModel : BaseViewModel
    {
        public CustomerListingViewModel()
        {
            CustomersList = new LinkedList<Customer>();
        }
        public IEnumerable<Customer> CustomersList { get; set; }

    }
}
