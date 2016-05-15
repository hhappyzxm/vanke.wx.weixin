using EZ.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class ExternalPersonnelDiningRegisterHistory : IEntity
    {
        public long ID { get; set; }

        public long StaffID { get; set; }

        public int CardNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        public ExternalPersonnelDiningRegisterStatus Status { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
