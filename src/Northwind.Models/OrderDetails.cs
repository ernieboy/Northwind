using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    [Table("Order Details")]
    public partial class OrderDetails
    {
        [Column("OrderID", TypeName = "int")]
        public long OrderId { get; set; }
        [Column("ProductID", TypeName = "int")]
        public long ProductId { get; set; }
        [Column(TypeName = "float(26)")]
        public double? UnitPrice { get; set; }
        [Column(TypeName = "int")]
        public long? Quantity { get; set; }
        [Column(TypeName = "float(13)")]
        public double? Discount { get; set; }
    }
}
