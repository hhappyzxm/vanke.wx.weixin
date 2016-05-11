using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WK.WX.WeiXin.Data.Entities
{
    public partial class DinnerRegisterHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public long StaffID { get; set; }

        public DateTime DinnerDate { get; set; }

        public int DinnerPeopleCount { get; set; }

        public long TypeID { get; set; }

        public long PlaceID { get; set; }

        [Column(TypeName = "text")]
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
