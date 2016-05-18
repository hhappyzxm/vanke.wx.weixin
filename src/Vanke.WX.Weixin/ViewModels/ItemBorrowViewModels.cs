using System;
using EZ.Framework;

namespace Vanke.WX.Weixin.ViewModels
{
    public class ItemBorrowViewModel : IViewModel
    {
        public long ID { get; set; }

        public string Staff { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public DateTime BorrowDateTime { get; set; }
    }
}