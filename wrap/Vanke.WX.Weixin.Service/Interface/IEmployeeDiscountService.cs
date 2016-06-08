using System.Collections.Generic;
using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IEmployeeDiscountService : ICRUDAsyncService<EmployeeDiscountModel>
    {

        Task<IEnumerable<EmployeeDiscountModel>> GetAllAsync(EmployeeDiscountType? filterType);
    }
}
