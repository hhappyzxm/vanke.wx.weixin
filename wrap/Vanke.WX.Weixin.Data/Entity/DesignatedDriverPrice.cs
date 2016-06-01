using System;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class DesignatedDriverPrice : IEntity
    {
        public long ID { get; set; }
        
        public long DesignatedDriverID { get; set; }

        [StringLength(50)]
        public string Distance { get; set; }

        [StringLength(50)]
        public string FirstTimePeriodsPrice { get; set; }

        [StringLength(50)]
        public string SecondTimePeriodsPrice { get; set; }

        public virtual DesignatedDriver DesignatedDriver { get; set; }
    }
}
