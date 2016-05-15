namespace Vanke.WX.Weixin.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExternalPersonnelDiningRegisterHistory
    {
        public long ID { get; set; }

        public long StaffID { get; set; }

        public int CardNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        public int Status { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
