using EZ.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class DinnerType : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DinnerType()
        {
            DinnerRegisterHistories = new HashSet<DinnerRegisterHistory>();
        }
        
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public DinnerTypeStatus Status { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DinnerRegisterHistory> DinnerRegisterHistories { get; set; }
    }
}
