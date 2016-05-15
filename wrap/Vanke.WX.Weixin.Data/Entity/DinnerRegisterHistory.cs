using System;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class DinnerRegisterHistory : IEntity
    {
        public long ID { get; set; }

        public long StaffID { get; set; }

        public DateTime DinnerDate { get; set; }

        public int DinnerPeopleCount { get; set; }

        public long TypeID { get; set; }

        public long PlaceID { get; set; }

        public int Status { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public virtual DinnerPlace DinnerPlace { get; set; }

        public virtual DinnerType DinnerType { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
