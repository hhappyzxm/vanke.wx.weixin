using System;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class Admin : IEntity
    {
        public long ID { get; set; }

        public long UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string RealName { get; set; }

        public AdminStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public virtual User User { get; set; }
    }
}
