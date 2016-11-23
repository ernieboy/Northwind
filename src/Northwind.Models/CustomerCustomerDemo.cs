using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class CustomerCustomerDemo
    {
        [Column("CustomerID", TypeName = "varchar(5)")]
        public string CustomerId { get; set; }
        [Column("CustomerTypeID", TypeName = "varchar(10)")]
        public string CustomerTypeId { get; set; }
    }
}
