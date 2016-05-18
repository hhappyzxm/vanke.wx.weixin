using System;
using EZ.Framework;

namespace Vanke.WX.Weixin.Service.Models
{
    public class ItemBorrowModel : IModel
    {
        public long ID { get; set; }

        public string Staff { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public DateTime BorrowTime { get; set; }

        public DateTime? CancelledTime { get; set; }
    }
}