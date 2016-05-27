using System;
using System.Collections.Generic;
using EZ.Framework;

namespace Vanke.WX.Weixin.Common
{
    public class CurrentLogin : ICurrentLogin
    {
        public object ID { get; set; }

        public string UserName { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
