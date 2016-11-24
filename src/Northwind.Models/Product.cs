using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common.Data.Interfaces;
using Core.Common.Data.Models;
using Core.Common.Utilities;

namespace Northwind.Models
{
    public sealed class Product : BaseObjectWithState, IObjectWithState
    {
        public Product()
        {
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

        [Key]
        [Column("ProductID", TypeName = "int")]
        public long ProductId { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string ProductName { get; set; }
        [Column("SupplierID", TypeName = "int")]
        public long? SupplierId { get; set; }
        [Column("CategoryID", TypeName = "int")]
        public long? CategoryId { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string QuantityPerUnit { get; set; }
        [Column(TypeName = "float(26)")]
        public double? UnitPrice { get; set; }
        [Column(TypeName = "int")]
        public long? UnitsInStock { get; set; }
        [Column(TypeName = "int")]
        public long? UnitsOnOrder { get; set; }
        [Column(TypeName = "int")]
        public long? ReorderLevel { get; set; }
        [Column(TypeName = "int")]
        public long Discontinued { get; set; }
    }
}
