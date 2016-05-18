using System;
using EZ.Framework;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class IdleAsset : IEntity
    {
        public long ID { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
}
