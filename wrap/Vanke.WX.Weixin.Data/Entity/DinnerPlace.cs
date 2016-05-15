using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class DinnerPlace : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DinnerPlace()
        {
            DinnerRegisterHistories = new HashSet<DinnerRegisterHistory>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Place { get; set; }

        public DinnerPlaceStatus Status { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DinnerRegisterHistory> DinnerRegisterHistories { get; set; }
    }
}
