using System;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class ExternalPersonnelDiningRegisterModel : IModel
    {
        public long ID { get; set; }

        public string Staff { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public ItemBorrowStatus Status { get; set; }

        public DateTime BorrowedOn { get; set; }

        public DateTime? CancelledOn { get; set; }
    }
}