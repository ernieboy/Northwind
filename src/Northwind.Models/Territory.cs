using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common.Data.Interfaces;
using Core.Common.Data.Models;
using Core.Common.Utilities;

namespace Northwind.Models
{
    public sealed class Territory : BaseObjectWithState, IObjectWithState
    {
        public Territory()
        {
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

        [Key]
        [Column("TerritoryID", TypeName = "varchar(20)")]
        public string TerritoryId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string TerritoryDescription { get; set; }
        [Column("RegionID", TypeName = "int")]
        public long RegionId { get; set; }
    }
}
