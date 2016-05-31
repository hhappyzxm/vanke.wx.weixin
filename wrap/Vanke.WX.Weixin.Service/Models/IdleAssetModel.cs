using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class IdleAssetModel : IModel
    {
        public long ID { get; set; }

        public long AreaID { get; set; }

        public string Area { get; set; }

        public long PlaceID { get; set; }

        public string Place { get; set; }

        public long ItemID { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public long ManagerStaffID { get; set; }

        public string ManagerStaff { get; set; }

        public string Comment { get; set; }

        public IdleAssetStatus Status { get; set; }
    }
}