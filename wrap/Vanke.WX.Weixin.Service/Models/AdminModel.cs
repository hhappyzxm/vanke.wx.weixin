using EZ.Framework;

namespace Vanke.WX.Weixin.Service.Models
{
    public class AdminModel : IModel
    {
        public long ID { get; set; }

        public string RealName { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }
    }
}