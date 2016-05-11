using System;
using EZ.Framework.Core;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class Admin : IEntity
    {
        public long ID { get; set; }

        public long UserID { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public virtual User User { get; set; }
    }
}
