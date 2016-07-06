using System;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class Setting : IEntity
    {
        public long ID { get; set; }

        public string IdleAssetDescription { get; set; }
    }
}
