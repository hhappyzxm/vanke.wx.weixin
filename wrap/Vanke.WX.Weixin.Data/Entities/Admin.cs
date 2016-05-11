using System;

namespace WK.WX.WeiXin.Data.Entities
{
    public partial class Admin
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
