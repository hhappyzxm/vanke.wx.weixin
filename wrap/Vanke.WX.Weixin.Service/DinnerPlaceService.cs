using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.EntityFramework;
using EZ.Framework.Integration.WebApi;
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

        protected override async Task BeforeInsertAsync(DinnerPlace entity)
        {
            await CheckPlaceExist(entity);

            entity.Status = DinnerPlaceStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
        }

        protected override async Task BeforeUpdateAsync(DinnerPlace entity)
        {
            await CheckPlaceExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
        }

        public override async Task<IEnumerable<DinnerPlace>> GetAllAsync()
        {
            return await Repository.ToListAsync(p => p.Status == DinnerPlaceStatus.Active);
        }

        private async Task CheckPlaceExist(DinnerPlace entity)
        {
            if (await Repository.AnyAsync(p => p.Place.Equals(entity.Place) && p.ID != entity.ID))
            {
                throw new BusinessException("宴请地点已经存在");
            }
        }
    }
}
