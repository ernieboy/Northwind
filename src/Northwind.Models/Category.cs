using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common.Data.Interfaces;
using Core.Common.Data.Models;
using Core.Common.Utilities;

namespace Northwind.Models
{
    public sealed class Category : BaseObjectWithState, IObjectWithState
    {
        public Category()
        {
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

        [Key]
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
