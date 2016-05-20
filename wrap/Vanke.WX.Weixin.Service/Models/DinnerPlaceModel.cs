using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class DinnerPlaceModel : IModel
    {
        public long ID { get; set; }
        
        public string Place { get; set; }

        public DinnerPlaceStatus Status { get; set; }
    }
}