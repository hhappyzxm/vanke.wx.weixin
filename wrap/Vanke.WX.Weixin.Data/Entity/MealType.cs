using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class MealType : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MealType()
        {
            ExternalPersonnelDiningRegisterHistories = new HashSet<ExternalPersonnelDiningRegisterHistory>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public MealTypeStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExternalPersonnelDiningRegisterHistory> ExternalPersonnelDiningRegisterHistories { get; set; }
    }
}
