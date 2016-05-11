using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WK.WX.WeiXin.Data.Entities
{
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            DinnerRegisterHistories = new HashSet<DinnerRegisterHistory>();
        }

        public long ID { get; set; }

        public long UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string RealName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DinnerRegisterHistory> DinnerRegisterHistories { get; set; }

        public virtual ExternalPersonnelDiningRegisterHistory ExternalPersonnelDiningRegisterHistory { get; set; }
    }
}
