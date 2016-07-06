using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class SettingModel : IModel
    {
        public long ID { get; set; }

        public string IdleAssetDescription { get; set; }
    }
}