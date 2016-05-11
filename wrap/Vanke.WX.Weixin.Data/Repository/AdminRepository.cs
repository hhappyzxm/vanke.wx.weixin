using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class AdminRepository : EFRepository<Admin>
    {
        public AdminRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
