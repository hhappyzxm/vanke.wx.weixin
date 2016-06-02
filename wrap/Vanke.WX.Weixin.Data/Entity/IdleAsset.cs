using System;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class IdleAsset : IEntity
    {
        public long ID { get; set; }

        public long AreaID { get; set; }

        public long PlaceID { get; set; }

        [Required]
        [StringLength(100)]
        public string Item { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        public long ManagerStaffID { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public IdleAssetStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public virtual ItemStorageArea Area { get; set; }

        public virtual ItemStoragePlace Place { get; set; }

        public virtual Staff ManagerStaff { get; set; }
    }
}
