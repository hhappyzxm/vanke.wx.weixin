using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class SurroundingServiceModel : IModel
    {
        public long ID { get; set; }

        public string ImagePath { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string UnitPrice { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Recommendation { get; set; }
    }
}