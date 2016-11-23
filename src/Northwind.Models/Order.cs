using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class Order
    {
        [Column("OrderID", TypeName = "int")]
        public long OrderId { get; set; }
        [Column("CustomerID", TypeName = "varchar(5)")]
        public string CustomerId { get; set; }
        [Column("EmployeeID", TypeName = "int")]
        public long? EmployeeId { get; set; }
        [Column(TypeName = "timestamp")]
        public string OrderDate { get; set; }
        [Column(TypeName = "timestamp")]
        public string RequiredDate { get; set; }
        [Column(TypeName = "timestamp")]
        public string ShippedDate { get; set; }
        [Column(TypeName = "int")]
        public long? ShipVia { get; set; }
        [Column(TypeName = "float(26)")]
        public double? Freight { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string ShipName { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string ShipAddress { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string ShipCity { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string ShipRegion { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string ShipPostalCode { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string ShipCountry { get; set; }
    }
}
