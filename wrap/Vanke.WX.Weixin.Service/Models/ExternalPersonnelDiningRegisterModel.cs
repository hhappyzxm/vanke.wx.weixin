using System;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class ExternalPersonnelDiningRegisterModel : IModel
    {
        public long ID { get; set; }

        public string Staff { get; set; }

        public int CardQuantity { get; set; }

        public string Comment { get; set; }

        public ExternalPersonnelDiningRegisterStatus Status { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? CancelledOn { get; set; }
    }
}