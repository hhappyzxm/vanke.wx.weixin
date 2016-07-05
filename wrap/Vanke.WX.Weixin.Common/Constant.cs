using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanke.WX.Weixin.Common
{
    public enum StaffStatus
    {
        Active,
        Removed
    }

    public enum Role
    {
        Admin,
        Staff,
        ExternalPersonnelDiningManager,
        ItemBorrowManager
    }

    public enum StaffRoleStatus
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

    public enum ItemStorageAreaStatus
    {
        Active,
        Removed
    }

    public enum ItemStoragePlaceStatus
    {
        Active,
        Removed
    }

    public enum IdleAssetStatus
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
        Cancelled,
        Removed
    }

    public enum DinnerRegisterStatus
    {
        Active,
        Cancelled,
        Removed
    }

    public enum DesignatedDriverStatus
    {
        Active,
        Removed
    }

    public enum SurroundingServiceStatus
    {
        Active,
        Removed
    }

    public enum EmployeeDiscountStatus
    {
        Active,
        Removed
    }

    public enum EmployeeDiscountType
    {
        Clothes,
        Food,
        Live,
        Walk,
        Health
    }
}
