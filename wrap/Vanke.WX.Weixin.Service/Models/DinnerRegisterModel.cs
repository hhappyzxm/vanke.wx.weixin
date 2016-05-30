using System;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Service.Models
{
    public class DinnerRegisterModel : IModel
    {
        public long ID { get; set; }

        public string Staff { get; set; }

        public DateTime DinnerDate { get; set; }

        public int PeopleCount { get; set; }

        public string Type { get; set; }

        public string Place { get; set; }

        public string Comment { get; set; }

        public DinnerRegisterStatus Status { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? CancelledOn { get; set; }
    }
}