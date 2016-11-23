using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class Shipper
    {
        [Column("ShipperID", TypeName = "int")]
        public long ShipperId { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string CompanyName { get; set; }
        [Column(TypeName = "varchar(24)")]
        public string Phone { get; set; }
    }
}
