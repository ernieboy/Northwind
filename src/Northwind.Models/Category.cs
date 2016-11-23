using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class Category
    {
        [Column("CategoryID", TypeName = "int")]
        public long CategoryId { get; set; }
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string CategoryName { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "blob")]
        public byte[] Picture { get; set; }
    }
}
