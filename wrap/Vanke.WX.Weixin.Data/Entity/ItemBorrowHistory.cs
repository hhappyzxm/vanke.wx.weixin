using System;
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

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public virtual Item Item { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
