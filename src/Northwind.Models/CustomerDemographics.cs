using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public sealed class CustomerDemographics
    {
        [Column("CustomerTypeID", TypeName = "varchar(10)")]
        public string CustomerTypeId { get; set; }
        [Column(TypeName = "text")]
        public string CustomerDesc { get; set; }
    }
}
