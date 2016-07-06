using System;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class ItemBorrowHistory : IEntity
    {
        public long ID { get; set; }

        public long ItemID { get; set; }

        public long StaffID { get; set; }

        public int Quantity { get; set; }

        public ItemBorrowStatus Status { get; set; }

        [StringLength(50)]
        public string Comment { get; set; }

        public DateTime BorrowedOn { get; set; }

        public DateTime? CancelledOn { get; set; }

        public long? CancelledBy { get; set; }

        public long? ReturnedBy { get; set; }

        public DateTime? ReturnedOn { get; set; }

        public virtual Item Item { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
