using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class DesignatedDriver : IEntity
    {
        public DesignatedDriver()
        {
            DesignatedDriverPrices = new HashSet<DesignatedDriverPrice>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverName { get; set; }

        [StringLength(50)]
        public string ServiceArea { get; set; }

        [StringLength(50)]
        public string BusinessRequirement { get; set; }

        [StringLength(50)]
        public string ContactPhone { get; set; }

        [StringLength(50)]
        public string PersonalRequirement { get; set; }

        [StringLength(50)]
        public string DrivingPhone { get; set; }

        [StringLength(50)]
        public string FirstTimePeriods { get; set; }

        [StringLength(50)]
        public string SecondTimePeriods { get; set; }

        public DesignatedDriverStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DesignatedDriverPrice> DesignatedDriverPrices { get; set; }
    }
}
