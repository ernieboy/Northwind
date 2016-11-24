using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common.Data.Interfaces;
using Core.Common.Data.Models;
using Core.Common.Utilities;

namespace Northwind.Models
{
    public sealed class Region : BaseObjectWithState, IObjectWithState
    {
        public Region()
        {
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }
        [Key]
        [Column("RegionID", TypeName = "int")]
        public long RegionId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string RegionDescription { get; set; }
    }
}
