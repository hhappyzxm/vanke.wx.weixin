using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class ItemStoragePlace : IEntity
    {
        public ItemStoragePlace()
        {
            IdleAssets = new HashSet<IdleAsset>();
        }

        public long ID { get; set; }

        public long AreaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Place { get; set; }

        public ItemStoragePlaceStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public virtual ItemStorageArea Area { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IdleAsset> IdleAssets { get; set; }
    }
}
