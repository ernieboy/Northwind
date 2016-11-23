using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class EmployeeTerritory
    {
        [Column("EmployeeID", TypeName = "int")]
        public long EmployeeId { get; set; }
        [Column("TerritoryID", TypeName = "varchar(20)")]
        public string TerritoryId { get; set; }
    }
}
