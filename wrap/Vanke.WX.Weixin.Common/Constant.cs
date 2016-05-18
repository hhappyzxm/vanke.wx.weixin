using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanke.WX.Weixin.Common
{
    public enum UserType
    {
        Admin,
        Staff
    }

    public enum AdminStatus
    {
        Active,
        Removed
    }

    public enum StaffStatus
    {
        Active,
        Removed
    }

    public enum DinnerTypeStatus
    {
        Active,
        Removed
    }

    public enum DinnerPlaceStatus
    {
        Active,
        Removed
    }

    public enum ItemStatus
    {
        Active,
        Removed
    }

    public enum ItemBorrowStatus
    {
        Active,
        Cancelled,
        Removed
    }

    public enum ExternalPersonnelDiningRegisterStatus
    {
        Active,
        Cancelled
    }
}
