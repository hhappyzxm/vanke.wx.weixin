using System.Collections.Generic;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class StaffModel : IModel
    {
        public long ID { get; set; }

        public string RealName { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public StaffStatus Status { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}