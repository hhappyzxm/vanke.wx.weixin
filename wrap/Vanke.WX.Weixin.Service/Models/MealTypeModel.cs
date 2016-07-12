using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class MealTypeModel : IModel
    {
        public long ID { get; set; }
        
        public string Type { get; set; }

        public MealTypeStatus Status { get; set; }
    }
}