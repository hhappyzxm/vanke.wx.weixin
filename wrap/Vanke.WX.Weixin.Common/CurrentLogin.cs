using EZ.Framework;

namespace Vanke.WX.Weixin.Common
{
    public class CurrentLogin : ICurrentLogin
    {
        public object ID { get; set; }

        public string UserName { get; set; }
    }
}
