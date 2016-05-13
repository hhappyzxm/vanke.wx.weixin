using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Admin : IEntity
    {
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string RealName { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public UserStatus Status { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
}
