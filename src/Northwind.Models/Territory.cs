using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class Territory
    {
        [Column("TerritoryID", TypeName = "varchar(20)")]
        public string TerritoryId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string TerritoryDescription { get; set; }
        [Column("RegionID", TypeName = "int")]
        public long RegionId { get; set; }
    }
}
