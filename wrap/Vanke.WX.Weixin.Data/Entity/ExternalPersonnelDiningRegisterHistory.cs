using System;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class ExternalPersonnelDiningRegisterHistory : IEntity
    {
        public long ID { get; set; }

        public long StaffID { get; set; }

        public long DinnerTypeID { get; set; }

        public int CardQuantity { get; set; }

        public string Department { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public ExternalPersonnelDiningRegisterStatus Status { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? CancelledOn { get; set; }

        public long? CancelledBy { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual DinnerType DinnerType { get; set; }
    }
}
