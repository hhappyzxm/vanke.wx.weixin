using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class EmployeeDiscountModel : IModel
    {
        public long ID { get; set; }

        public EmployeeDiscountType Type { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Discount { get; set; }
    }
}