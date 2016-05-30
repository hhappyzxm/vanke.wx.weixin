using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class ItemStoragePlaceModel : IModel
    {
        public long ID { get; set; }

        public long AreaID { get; set; }

        public string Area { get; set; }

        public string Place { get; set; }

        public ItemStoragePlaceStatus Status { get; set; }
    }
}