using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class ItemStorageArea : IEntity
    {
        public ItemStorageArea()
        {
            IdleAssets = new HashSet<IdleAsset>();
            ItemStoragePlaces = new HashSet<ItemStoragePlace>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        public ItemStorageAreaStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IdleAsset> IdleAssets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemStoragePlace> ItemStoragePlaces { get; set; }
    }
}
