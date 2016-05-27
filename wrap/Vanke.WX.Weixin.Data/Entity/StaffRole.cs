using System;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class StaffRole : IEntity
    {
        public long ID { get; set; }

        public long StaffID { get; set; }

        public Role Role { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
