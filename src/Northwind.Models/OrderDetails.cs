using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common.Data.Interfaces;
using Core.Common.Data.Models;
using Core.Common.Utilities;

namespace Northwind.Models
{
    [Table("Order Details")]
    public sealed class OrderDetails : BaseObjectWithState, IObjectWithState
    {
        public OrderDetails()
        {
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

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
