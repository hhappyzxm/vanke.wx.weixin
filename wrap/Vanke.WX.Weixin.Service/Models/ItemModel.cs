using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class ItemModel : IModel
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public ItemStatus Status { get; set; }
    }
}