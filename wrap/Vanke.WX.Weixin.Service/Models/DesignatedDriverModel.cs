using System.Collections.Generic;
using EZ.Framework;

namespace Vanke.WX.Weixin.Service.Models
{
    public class DesignatedDriverModel : IModel
    {
        public long ID { get; set; }

        public string DriverName { get; set; }

        public string ServiceArea { get; set; }

        public string BusinessRequirement { get; set; }

        public string ContactPhone { get; set; }

        public string PersonalRequirement { get; set; }

        public string DrivingPhone { get; set; }

        public string CustomFirstColumn { get; set; }

        public string CustomSecondColumn { get; set; }

        public string CustomThirdColumn { get; set; }

        public ICollection<DesignatedDriverPriceModel> Prices { get; set; }
    }

    public class DesignatedDriverPriceModel : IModel
    {
        public string Distance { get; set; }

        public string FirstTimePeriodsPrice { get; set; }

        public string SecondTimePeriodsPrice { get; set; }
    }

}