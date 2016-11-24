using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common.Data.Interfaces;
using Core.Common.Data.Models;
using Core.Common.Utilities;


namespace Northwind.Models
{
    public sealed class Customer : BaseObjectWithState, IObjectWithState
    {
        public Customer()
        {
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

        [Key]
        [Column("CustomerID", TypeName = "varchar(5)")]
        public string CustomerId { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string CompanyName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string ContactName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string ContactTitle { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Region { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string PostalCode { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(24)")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(24)")]
        public string Fax { get; set; }
    }
}
