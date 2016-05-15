using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Service
{
    public class DinnerPlaceService : CRUDService<IDataContext, IDinnerPlaceRepository, DinnerPlace>, IDinnerPlaceService
    {
        public DinnerPlaceService(IDataContext dataContext, IDinnerPlaceRepository repository) : base(dataContext, repository)
        {
        }

        public override async Task<IEnumerable<DinnerPlace>> GetAllAsync()
        {
            return await Repository.ToListAsync(p => p.Status == DinnerPlaceStatus.Active);
        }
    }
}
