using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class StaffRepository : EFRepository<Staff>
    {
        public StaffRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
