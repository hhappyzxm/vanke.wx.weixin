using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class ExternalPersonnelDiningRegisterRepository : EFRepository<ExternalPersonnelDiningRegisterHistory>, IExternalPersonnelDiningRegisterRepository
    {
        public ExternalPersonnelDiningRegisterRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
