using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class Region
    {
        [Column("RegionID", TypeName = "int")]
        public long RegionId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string RegionDescription { get; set; }
    }
}
