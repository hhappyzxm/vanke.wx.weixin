using EZ.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class Staff : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            DinnerRegisterHistories = new HashSet<DinnerRegisterHistory>();
            ItemBorrowHistories = new HashSet<ItemBorrowHistory>();
        }

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

        public StaffStatus Status { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DinnerRegisterHistory> DinnerRegisterHistories { get; set; }

        public virtual ExternalPersonnelDiningRegisterHistory ExternalPersonnelDiningRegisterHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemBorrowHistory> ItemBorrowHistories { get; set; }
    }
}
