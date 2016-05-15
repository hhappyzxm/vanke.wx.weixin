using EZ.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Vanke.WX.Weixin.Data.Entity
{
    

    public partial class Hotel : IEntity
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
}
