using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common.Data.Interfaces;
using Core.Common.Data.Models;
using Core.Common.Utilities;

namespace Northwind.Models
{
    public sealed class Shipper : BaseObjectWithState, IObjectWithState
    {
        public Shipper()
        {
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

        [Key]
        [Column("ShipperID", TypeName = "int")]
        public long ShipperId { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string CompanyName { get; set; }
        [Column(TypeName = "varchar(24)")]
        public string Phone { get; set; }
    }
}
