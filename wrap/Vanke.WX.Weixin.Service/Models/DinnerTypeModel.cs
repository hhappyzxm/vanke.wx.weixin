using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class DinnerTypeModel : IModel
    {
        public long ID { get; set; }
        
        public string Type { get; set; }

        public DinnerTypeStatus Status { get; set; }
    }
}