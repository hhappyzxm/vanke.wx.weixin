using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class ItemStorageAreaModel : IModel
    {
        public long ID { get; set; }

        public string Area { get; set; }

        public ItemStorageAreaStatus Status { get; set; }
    }
}