using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class ExternalPersonnelDiningRegisterRepository : EFRepository<ExternalPersonnelDiningRegisterHistory>, IExternalPersonnelDiningRegisterRepository
    {
        public ExternalPersonnelDiningRegisterRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override void Remove(ExternalPersonnelDiningRegisterHistory entity)
        {
            entity.Status = UserStatus.Removed;

            Update(entity);
        }
    }
}
