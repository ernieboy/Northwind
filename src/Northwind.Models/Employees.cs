using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class Employees
    {
        [Column("EmployeeID", TypeName = "int")]
        public long EmployeeId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string TitleOfCourtesy { get; set; }
        [Column(TypeName = "timestamp")]
        public string BirthDate { get; set; }
        [Column(TypeName = "timestamp")]
        public string HireDate { get; set; }
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
        public string HomePhone { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string Extension { get; set; }
        [Column(TypeName = "blob")]
        public byte[] Photo { get; set; }
        [Column(TypeName = "text")]
        public string Notes { get; set; }
        [Column(TypeName = "int")]
        public long? ReportsTo { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string PhotoPath { get; set; }
    }
}
